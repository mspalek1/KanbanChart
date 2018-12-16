using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevExpress.XtraGrid.Demos
{
    public partial class KanbanBoard : UserControl
    {
        BindingList<TaskRecord> tasksData;
        DataTable employeesData;
        DataTable membersData;
        DataTable checklistData;
        Image checkBadge;
        Image checkBadgeDone;

        public KanbanBoard()
        {
            InitializeComponent();
            InitData();
            tileView.OptionsEditForm.CustomEditFormLayout = new KanbanEditControl(tileView, employeesData, membersData, checklistData);
            checkBadge = KanbanHelper.CreateCheckBadge(Color.Gray);
            checkBadgeDone = KanbanHelper.CreateCheckBadge(GetLabelColor(TaskLabel.Green));
        }

        void InitData()
        {
            tasksData = KanbanHelper.LoadTasks();
            employeesData = KanbanHelper.LoadEmployees();
            membersData = KanbanHelper.LoadMembers();
            checklistData = KanbanHelper.LoadChecklist();
            KanbanHelper.ProcessMembersPhoto(employeesData);
            gridControl.DataSource = tasksData;
        }

        void tileView_ItemCustomize(object sender, Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            var task = tileView.GetRow(e.RowHandle) as TaskRecord;
            if (task == null) return;
            e.Item["Label"].Appearance.Normal.BackColor = GetLabelColor(task.Label);
            e.Item["Description"].ImageVisible = !String.IsNullOrEmpty(task.Description);
            if (IsEmptyItem(e.RowHandle))
            {
                e.Item["Caption"].Text = "Add a card...";
                e.Item.AppearanceItem.Normal.BackColor = Color.LightGray;
                e.Item.AppearanceItem.Normal.ForeColor = Color.DarkGray;
                return;
            }
            UpdateProgressElement(e.Item, task.Id.ToString());
            var elements = GetMembersElements(task.Id.ToString());
            if (elements.Count == 0) return;
            TileViewItemElement prev = null;
            foreach (var element in elements)
            {
                e.Item.Elements.Add(element);
                if (prev != null)
                {
                    element.AnchorElement = prev;
                    element.AnchorAlignment = AnchorAlignment.Left;
                    element.AnchorIndent = 4;
                }
                else
                {
                    element.ImageAlignment = TileItemContentAlignment.BottomRight;
                }
                prev = element;
            }
        }
        void tileView_BeforeItemDrag(object sender, BeforeItemDragEventArgs e)
        {
            e.Cancel = IsEmptyItem(e.RowHandle);
        }
        void tileView_EditFormShowing(object sender, Views.Grid.EditFormShowingEventArgs e)
        {
            e.Allow = !IsEmptyItem(e.RowHandle);
        }
        void tileView_ItemDrop(object sender, ItemDropEventArgs e)
        {
            var newStatus = (TaskStatus)e.GroupColumnValue;
            var prevStatus = (TaskStatus)e.PrevGroupColumnValue;
            if (!prevStatus.Equals(newStatus))
            {
                tileView.BeginDataUpdate();
                RemoveEmptyItem(newStatus);
                AddEmptyItem(prevStatus);
                tileView.EndDataUpdate();
            }
        }
        void tileView_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            if (!IsEmptyItem(e.Item.RowHandle)) return;
            TaskStatus status = (TaskStatus)tileView.GetRowCellValue(e.Item.RowHandle, "Status");
            AddNewCard(status);
        }
        void UpdateProgressElement(TileViewItem item, string taskId)
        {
            if (item == null)
                return;
            var progressElement = item["Progress"];
            var descriptionElement = item["Description"];
            if (progressElement == null || descriptionElement == null)
                return;
            int count = checklistData.Select("TaskID = " + taskId).Count();
            int doneCount = checklistData.Select("TaskID = " + taskId + " AND Checked").Count();
            if (count == 0)
            {
                progressElement.Text = string.Empty;
                return;
            }
            progressElement.ImageVisible = true;
            progressElement.Image = checkBadge;
            progressElement.Text = String.Format("{0}/{1}", doneCount, count);
            if (!descriptionElement.ImageVisible) progressElement.AnchorIndent = 0;
            if (count == doneCount)
            {
                progressElement.Image = checkBadgeDone;
                progressElement.Appearance.Normal.ForeColor = GetLabelColor(TaskLabel.Green);
            }
        }
        List<TileViewItemElement> GetMembersElements(string taskId)
        {
            var memberRows = membersData.Select("TaskID = " + taskId);
            var result = new List<TileViewItemElement>();
            foreach (var memberRow in memberRows)
            {
                var photoBytes = employeesData.Rows.Find(memberRow["MemberID"])["Photo"];
                var element = new TileViewItemElement();
                element.Image = ByteImageConverter.FromByteArray(photoBytes as byte[]);
                result.Add(element);
            }
            return result;
        }
        Color GetLabelColor(TaskLabel label)
        {
            switch (label)
            {
                case TaskLabel.Red: return ColorTranslator.FromHtml("#f06562");
                case TaskLabel.Green: return ColorTranslator.FromHtml("#069c47");
                case TaskLabel.Yellow: return ColorTranslator.FromHtml("#e6c730");
                default: return Color.Empty;
            }
        }
        bool IsEmptyItem(int rowHandle)
        {
            var row = tileView.GetRow(rowHandle);
            if (row == null) return false;
            return (int)tileView.GetRowCellValue(rowHandle, "Id") < 0;
        }

        void AddNewCard(TaskStatus status)
        {
            string newCaption = XtraInputBox.Show("", "Add new card", "New Task");
            if (String.IsNullOrEmpty(newCaption)) return;
            var newRow = KanbanHelper.CreateNewTask();
            int maxId = tasksData.OrderByDescending(x => x.Id).ToList()[0].Id;
            newRow.Id = maxId + 1;
            newRow.Status = status;
            newRow.Caption = newCaption;
            tasksData.Add(newRow);
            tileView.FocusedRowHandle = tileView.GetRowHandle(tasksData.IndexOf(newRow));
            RemoveEmptyItem(newRow.Status);
        }

        void AddEmptyItem(TaskStatus status) { KanbanHelper.AddEmptyItem(tasksData, status); }
        void RemoveEmptyItem(TaskStatus status) { KanbanHelper.RemoveEmptyItem(tasksData, status); }
    }
}
