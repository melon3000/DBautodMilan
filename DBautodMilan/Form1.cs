using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using DBautodMilan.Models;

namespace DBautodMilan
{
    public partial class Form1 : Form
    {
        private readonly TimeSpan SlotStep = TimeSpan.FromMinutes(30);
        private readonly TimeSpan WorkDayStart = TimeSpan.FromHours(8); // 08:00
        private readonly TimeSpan WorkDayEnd = TimeSpan.FromHours(18);  // 18:00

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            dgvOwners.CellClick += dgvOwners_CellClick;
            dgvCars.CellClick += dgvCars_CellClick;

            dtServiceDate.ValueChanged += DtServiceDate_ValueChanged;
            cbCars.SelectedValueChanged += CbCars_SelectedValueChanged;
        }

        private sealed class TimeSlot
        {
            public DateTime Value { get; init; }
            public bool IsBooked { get; init; }
            public bool IsPast { get; init; }
            public string Display => $"{Value:HH:mm}" + (IsBooked ? " — hõivatud" : (IsPast ? " — Läbi" : ""));
        }

        // ============================================================
        // MAIN LOAD
        // ============================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOwners();
            LoadCars();
            LoadServices();
            LoadCarServices();
            LoadCombos();
            TryLoadTimeSlots();
        }

        private void LoadCombos()
        {
            using var db = new AutoDbContext();

            cbOwners.DataSource = db.Owners.ToList();
            cbOwners.DisplayMember = "FullName";
            cbOwners.ValueMember = "Id";

            cbCars.DataSource = db.Cars.ToList();
            cbCars.DisplayMember = "RegistrationNumber";
            cbCars.ValueMember = "Id";

            comboBox1.DataSource = db.Services.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
        // ============================================================
        // LOAD GRID FUNCTIONS
        // ============================================================
        private void LoadOwners()
        {
            using var db = new AutoDbContext();

            dgvOwners.DataSource = db.Owners
                .Select(o => new
                {
                    o.Id,
                    o.FullName,
                    o.Phone,
                    Cars = o.Cars.Count
                })
                .ToList();
        }

        private void LoadCars(int? ownerFilter = null)
        {
            using var db = new AutoDbContext();

            var query = db.Cars.Include(c => c.Owner).AsQueryable();

            if (ownerFilter != null)
                query = query.Where(c => c.OwnerId == ownerFilter);

            dgvCars.DataSource = query.Select(c => new
            {
                c.Id,
                c.Brand,
                c.Model,
                c.RegistrationNumber,
                Owner = c.Owner.FullName
            }).ToList();
        }

        private void LoadServices()
        {
            using var db = new AutoDbContext();

            dgvServices.DataSource = db.Services
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Price
                })
                .ToList();
        }

        // загрузка всех сервисов (с обновлением статусов прошедших записей)
        private void LoadCarServices()
        {
            using var db = new AutoDbContext();

            // Автоматически помечаем прошедшие записи как выполненные и кешируем цену (если ещё не кеширована)
            var now = DateTime.Now;
            var toComplete = db.CarServices
                              .Include(cs => cs.Service)
                              .Where(cs => cs.DateOfService <= now && !cs.Valmis)
                              .ToList();

            if (toComplete.Any())
            {
                foreach (var cs in toComplete)
                {
                    cs.Valmis = true;
                    cs.PriceCharged = cs.Service?.Price ?? 0m;
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Легкое логирование — не ломаем UI, но информируем
                    MessageBox.Show($"Не удалось обновить статус прошедших записей: {ex.Message}");
                }
            }

            dataGridView1.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .Include(cs => cs.Car.Owner)
                .Select(cs => new
                {
                    cs.Id,
                    Owner = cs.Car.Owner.FullName,
                    Phone = cs.Car.Owner.Phone,
                    Car = cs.Car.RegistrationNumber,
                    Service = cs.Service.Name,
                    cs.DateOfService,
                    cs.Labisoit,
                    cs.Valmis,
                    Price = cs.PriceCharged
                })
                .OrderByDescending(cs => cs.DateOfService)
                .ToList();
        }

        // ============================================================
        //   🔵 CLICK events — переходы между вкладками
        // ============================================================

        // ✔ Клик на владельца → переход на вкладку AUTOD с фильтром
        private void dgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            if (dgvOwners.CurrentRow.Cells["Id"].Value is not int ownerId) return;

            LoadCars(ownerId);

            Avaleht.SelectedTab = tabPage2;
        }

        // ✔ Клик на машину → переход к Hooldus и показ сервисов этой машины
        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            if (dgvCars.CurrentRow.Cells["Id"].Value is not int carId) return;

            using var db = new AutoDbContext();

            dataGridView1.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .Include(cs => cs.Car.Owner)
                .Where(cs => cs.CarId == carId)
                .Select(cs => new
                {
                    cs.Id,
                    Owner = cs.Car.Owner.FullName,
                    Phone = cs.Car.Owner.Phone,
                    Car = cs.Car.RegistrationNumber,
                    Service = cs.Service.Name,
                    cs.DateOfService,
                    cs.Labisoit,
                    cs.Valmis,
                    Price = cs.PriceCharged
                })
                .OrderBy(cs => cs.DateOfService)
                .ToList();

            Avaleht.SelectedTab = tabPage4;
        }

        // ============================================================
        // CRUD владельцев
        // ============================================================
        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            if (string.IsNullOrWhiteSpace(txtOwnerName.Text))
            {
                MessageBox.Show("Введите имя.");
                return;
            }

            db.Owners.Add(new Owner
            {
                FullName = txtOwnerName.Text.Trim(),
                Phone = txtOwnerPhone.Text.Trim()
            });

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении владельца: {ex.Message}");
                return;
            }

            LoadOwners();
            LoadCombos();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            if (dgvOwners.CurrentRow.Cells["Id"].Value is not int id) return;

            using var db = new AutoDbContext();

            var owner = db.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == id);

            if (owner == null) return;

            if (owner.Cars.Any())
            {
                MessageBox.Show("Нельзя удалить владельца — у него есть машины.");
                return;
            }

            db.Owners.Remove(owner);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении владельца: {ex.Message}");
                return;
            }

            LoadOwners();
            LoadCombos();
        }

        // ============================================================
        // CRUD машин
        // ============================================================
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            if (cbOwners.SelectedValue is not int ownerId)
            {
                MessageBox.Show("Выберите владельца.");
                return;
            }

            db.Cars.Add(new Car
            {
                Brand = txtBrand.Text.Trim(),
                Model = txtModel.Text.Trim(),
                RegistrationNumber = txtRegNumber.Text.Trim(),
                OwnerId = ownerId
            });

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении машины: {ex.Message}");
                return;
            }

            LoadCars();
            LoadCombos();
            LoadOwners();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            if (dgvCars.CurrentRow.Cells["Id"].Value is not int id) return;

            using var db = new AutoDbContext();

            var car = db.Cars.Include(c => c.CarServices).FirstOrDefault(c => c.Id == id);

            if (car == null) return;

            if (car.CarServices.Any())
            {
                MessageBox.Show("Нельзя удалить машину — есть записи о сервисе.");
                return;
            }

            db.Cars.Remove(car);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении машины: {ex.Message}");
                return;
            }

            LoadCars();
            LoadCombos();
            LoadOwners();
        }

        // ============================================================
        // CRUD обслуживания
        // ============================================================
        private void btnAddCarService_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            if (cbCars.SelectedValue is not int carId)
            {
                MessageBox.Show("Vali auto.");
                return;
            }

            if (comboBox1.SelectedValue is not int serviceId)
            {
                MessageBox.Show("Vali teenus.");
                return;
            }

            if (cbServiceTime?.SelectedItem is not TimeSlot selectedSlot)
            {
                MessageBox.Show("Vali aeg.");
                return;
            }

            // запрет выбора занятых слотов
            if (selectedSlot.IsBooked)
            {
                MessageBox.Show("Valitud aeg on juba broneeritud.");
                return;
            }

            // валидируем пробег
            if (!int.TryParse(txtMileage.Text.Trim(), out int mileage) || mileage < 0)
            {
                MessageBox.Show("Siseta labisoit.");
                return;
            }

            // создаём запись
            var svc = db.Services.FirstOrDefault(s => s.Id == serviceId);

            var carService = new CarService
            {
                CarId = carId,
                ServiceId = serviceId,
                DateOfService = selectedSlot.Value,
                Labisoit = mileage,
                // Если уже прошла — ставим Completed и кешируем цену
                Valmis = selectedSlot.Value <= DateTime.Now,
                PriceCharged = (selectedSlot.Value <= DateTime.Now) ? (svc?.Price ?? 0m) : 0m
            };

            db.CarServices.Add(carService);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи на сервис: {ex.Message}");
                return;
            }

            LoadCarServices();
            // обновляем слоты — выбранный слот теперь будет помечен как занятый
            TryLoadTimeSlots();
        }

        private void btnDeleteCarService_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            if (dataGridView1.CurrentRow.Cells["Id"].Value is not int id) return;

            using var db = new AutoDbContext();

            var record = db.CarServices.Include(c => c.Car).FirstOrDefault(cs => cs.Id == id);

            if (record == null) return;

            db.CarServices.Remove(record);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи сервиса: {ex.Message}");
                return;
            }

            LoadCarServices();
            TryLoadTimeSlots();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Введите название услуги.");
                return;
            }

            if (!decimal.TryParse(txtServicePrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            db.Services.Add(new Service
            {
                Name = txtServiceName.Text.Trim(),
                Price = price
            });

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении услуги: {ex.Message}");
                return;
            }

            LoadServices();
            LoadCombos();

            txtServiceName.Clear();
            txtServicePrice.Clear();
        }

        // ============================================================
        // New: remove selected service with safety checks
        // ============================================================
        private void btnRemService_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (dgvServices.CurrentRow == null) return;

            if (dgvServices.CurrentRow.Cells["Id"].Value is not int id) return;

            using var db = new AutoDbContext();

            // Load service including any related CarServices to check references
            var service = db.Services
                            .Include(s => s.CarServices)
                            .FirstOrDefault(s => s.Id == id);

            if (service == null) return;

            // Prevent deletion if there are dependent records
            if (service.CarServices != null && service.CarServices.Any())
            {
                MessageBox.Show("Нельзя удалить услугу — есть связанные записи о сервисе.");
                return;
            }

            // Confirm deletion with user
            var res = MessageBox.Show($"Удалить услугу \"{service.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            db.Services.Remove(service);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении услуги: {ex.Message}");
                return;
            }

            // Refresh UI
            LoadServices();
            LoadCombos();
        }

        // ============================================================
        // Временные слоты
        // ============================================================
        private void DtServiceDate_ValueChanged(object? sender, EventArgs e)
        {
            TryLoadTimeSlots();
        }

        private void CbCars_SelectedValueChanged(object? sender, EventArgs e)
        {
            TryLoadTimeSlots();
        }

        // Попытаться загрузить слоты, без выбрасывания исключения, если контрол не создан
        private void TryLoadTimeSlots()
        {
            try
            {
                LoadTimeSlots(dtServiceDate.Value.Date);
            }
            catch
            {
                // если формы/контролы ещё нет — ничего не делаем
            }
        }

        // Генерация слотов с шагом 30 минут. Помечаем занятые и прошедшие.
        private void LoadTimeSlots(DateTime date)
        {
            if (cbServiceTime == null) return; // защитно — если контрол не добавлен в designer

            int selectedCarId = (cbCars.SelectedValue is int id) ? id : -1;

            using var db = new AutoDbContext();

            var slots = new List<TimeSlot>();
            for (var t = WorkDayStart; t <= WorkDayEnd; t = t.Add(SlotStep))
            {
                var slotDt = date.Date + t;

                // Не показываем слоты, если время уже прошло
                if (slotDt <= DateTime.Now)
                    continue;

                bool isBooked = db.CarServices.Any(cs => cs.DateOfService == slotDt && cs.CarId != selectedCarId);
                bool isPast = slotDt <= DateTime.Now;
                slots.Add(new TimeSlot { Value = slotDt, IsBooked = isBooked, IsPast = isPast });
            }

            cbServiceTime.DataSource = slots;
            cbServiceTime.DisplayMember = "Display";
            cbServiceTime.ValueMember = "Value";

        }

        private void btnResetCarFilter_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCars.ClearSelection();
            }
            catch
            {
                // ignore if grid not initialized
            }

            LoadCarServices();
            Avaleht.SelectedTab = tabPage4;
        }
    }
}
