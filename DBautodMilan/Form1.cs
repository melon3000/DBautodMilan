using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using DBautodMilan.Models; // пространство имён с моделями

namespace DBautodMilan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            // Привязываем обработчики кнопок
            btnAddOwner.Click += btnAddOwner_Click;
            btnDeleteOwner.Click += btnDeleteOwner_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOwners();
        }

        private void LoadOwners()
        {
            using var db = new AutoDbContext();
            dgvOwners.DataSource = db.Owners.ToList();
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            string fullName = txtOwnerName.Text.Trim();
            string phone = txtOwnerPhone.Text.Trim();

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Введите имя владельца.");
                return;
            }

            using var db = new AutoDbContext();

            var owner = new Owner
            {
                FullName = fullName,
                Phone = phone
            };

            db.Owners.Add(owner);
            db.SaveChanges();

            LoadOwners();

            // Очистим поля после добавления
            txtOwnerName.Clear();
            txtOwnerPhone.Clear();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null)
            {
                MessageBox.Show("Выберите владельца для удаления.");
                return;
            }

            int ownerId = (int)dgvOwners.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var owner = db.Owners.Find(ownerId);

            if (owner != null)
            {
                var confirmResult = MessageBox.Show($"Удалить владельца \"{owner.FullName}\"?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    db.Owners.Remove(owner);
                    db.SaveChanges();
                    LoadOwners();
                }
            }
        }
    }
}
