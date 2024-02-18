using ClientProject.GUIControllers;
using Common.Domain;
using Common.Enums;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls
{
    public partial class StartupEventRegistrationUC : UserControl
    {
        public Label LblTitle => lblQuestions;
        public Button BtnConfirm => btnConfirm;

        private int _startupEventId;
        private bool _isEditing;

        public StartupEventRegistrationUC(bool isEditing, int startupEventId, StartupEventRegistration registration = null, List<RegisteredQuestion> questions = null)
        {
            _startupEventId = startupEventId;
            _isEditing = isEditing;

            InitializeComponent();
            InitializeQuestionsTable(isEditing, questions);
            InitializeComboBox(registration);
        }

        private void InitializeComboBox(StartupEventRegistration registration)
        {
            cmbStatus.DataSource = new BindingList<RegistrationStatus> { RegistrationStatus.Attending, RegistrationStatus.Cancelling };

            if (registration == null)
            {
                cmbStatus.Enabled = false;
            }
            else
            {
                cmbStatus.SelectedItem = registration.Status;
            }
        }

        private void InitializeQuestionsTable(bool isEditing, List<RegisteredQuestion> questions)
        {
            dgvQuestions.DataSource = (questions != null) ? new BindingList<RegisteredQuestion>(questions)
                                                          : new BindingList<RegisteredQuestion>();
            dgvQuestions.AllowUserToAddRows = !isEditing;
            dgvQuestions.AllowUserToDeleteRows = !isEditing;

            for(int i = 0; i < dgvQuestions.Columns.Count; i++)
            {
                if (i == 3 || i == 4) continue;

                dgvQuestions.Columns[i].Visible = false;
            }

            dgvQuestions.AllowUserToOrderColumns = false;
            dgvQuestions.ReadOnly = false;
        }

        public FullRegistration GetFullRegistration()
        {
            int userId = MainCoordinator.Instance.ConnectedUser.Id;

            var registration = new StartupEventRegistration
            {
                DateOfRegistration = DateTime.Now,
                Status = (RegistrationStatus)cmbStatus.SelectedItem,
                UserId = userId,
                EventId = _startupEventId
            };

            var questions = new List<RegisteredQuestion>();

            foreach(DataGridViewRow row in dgvQuestions.Rows)
            {
                if (row.Cells[3].Value == null || row.Cells[4].Value == null) continue;

                var question = new RegisteredQuestion
                {
                    Question = row.Cells[3].Value?.ToString(),
                    Description = row.Cells[4].Value?.ToString(),
                    EventId = _startupEventId,
                    UserId = userId
                };

                if (_isEditing)
                {
                    question.Id = (int)row.Cells[0].Value;
                };

                questions.Add(question);
            }

            return new FullRegistration(registration,  questions);
        }
    }
}
