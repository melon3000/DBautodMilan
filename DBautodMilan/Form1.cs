using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using DBautodMilan.Models;

namespace DBautodMilan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            dgvOwners.CellClick += dgvOwners_CellClick;
            dgvCars.CellClick += dgvCars_CellClick;
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

        // загрузка всех сервисов (только первый запуск)
        private void LoadCarServices()
        {
            using var db = new AutoDbContext();

            dataGridView1.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .Include(cs => cs.Car.Owner)
                .Select(cs => new
                {
                    Owner = cs.Car.Owner.FullName,
                    Phone = cs.Car.Owner.Phone,
                    Car = cs.Car.RegistrationNumber,
                    Service = cs.Service.Name,
                    cs.DateOfService,
                    cs.Mileage
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

            int ownerId = (int)dgvOwners.CurrentRow.Cells["Id"].Value;

            // сортируем машины по ownerid
            LoadCars(ownerId);

            // переключение на вкладку AUTOD
            Avaleht.SelectedTab = tabPage2;
        }

        // ✔ Клик на машину → переход к Hooldus и показ сервисов этой машины
        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            int carId = (int)dgvCars.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();

            dataGridView1.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .Include(cs => cs.Car.Owner)
                .Where(cs => cs.CarId == carId)
                .Select(cs => new
                {
                    Owner = cs.Car.Owner.FullName,
                    Phone = cs.Car.Owner.Phone,
                    Car = cs.Car.RegistrationNumber,
                    Service = cs.Service.Name,
                    cs.DateOfService,
                    cs.Mileage
                })
                .OrderBy(cs => cs.Car)
                .ThenBy(cs => cs.Owner)
                .ToList();

            // и переходим на вкладку hooldus
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

            db.SaveChanges();

            LoadOwners();
            LoadCombos();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            int id = (int)dgvOwners.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();

            var owner = db.Owners.Include(o => o.Cars).First(o => o.Id == id);

            if (owner.Cars.Any())
            {
                MessageBox.Show("Нельзя удалить владельца — у него есть машины.");
                return;
            }

            db.Owners.Remove(owner);
            db.SaveChanges();

            LoadOwners();
            LoadCombos();
        }

        // ============================================================
        // CRUD машин
        // ============================================================
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            db.Cars.Add(new Car
            {
                Brand = txtBrand.Text.Trim(),
                Model = txtModel.Text.Trim(),
                RegistrationNumber = txtRegNumber.Text.Trim(),
                OwnerId = (int)cbOwners.SelectedValue
            });

            db.SaveChanges();

            LoadCars();
            LoadCombos();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            int id = (int)dgvCars.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();

            var car = db.Cars.Include(c => c.CarServices).First(c => c.Id == id);

            if (car.CarServices.Any())
            {
                MessageBox.Show("Нельзя удалить машину — есть записи о сервисе.");
                return;
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            LoadCars();
            LoadCombos();
        }

        // ============================================================
        // CRUD обслуживания
        // ============================================================
        private void btnAddCarService_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            int carId = (int)cbCars.SelectedValue;
            int serviceId = (int)comboBox1.SelectedValue;
            DateTime date = dtServiceDate.Value.Date;

            // проверка занято ли время другой машиной
            bool busy = db.CarServices.Any(cs => cs.DateOfService == date && cs.CarId != carId);

            if (busy)
            {
                MessageBox.Show("Это время уже занято другой машиной.");
                return;
            }

            db.CarServices.Add(new CarService
            {
                CarId = carId,
                ServiceId = serviceId,
                DateOfService = date,
                Mileage = int.Parse(txtMileage.Text.Trim())
            });

            db.SaveChanges();

            LoadCarServices();
        }

        private void btnDeleteCarService_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string reg = dataGridView1.CurrentRow.Cells["Car"].Value.ToString();

            using var db = new AutoDbContext();

            var record = db.CarServices.Include(c => c.Car)
                                       .First(cs => cs.Car.RegistrationNumber == reg);

            db.CarServices.Remove(record);
            db.SaveChanges();

            LoadCarServices();
        }
        private void btnAddService_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();

            // проверка на пустое имя услуги
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Введите название услуги.");
                return;
            }

            // проверка цены
            if (!decimal.TryParse(txtServicePrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            // добавляем услугу
            db.Services.Add(new Service
            {
                Name = txtServiceName.Text.Trim(),
                Price = price
            });

            db.SaveChanges();

            // обновляем таблицу и комбобоксы
            LoadServices();
            LoadCombos();

            // очищаем поля
            txtServiceName.Clear();
            txtServicePrice.Clear();
        }
    }
}
