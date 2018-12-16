using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace DevExpress.XtraGrid.Demos {
    public partial class KanbanEditControl : EditFormUserControl {
        DevExpress.XtraGrid.Views.Tile.TileView OwnerView;
        GridControl OwnerGrid { get { return OwnerView.GridControl; } }
        DataTable Employees { get; set; }
        DataTable Members { get; set; }
        DataTable Checklist { get; set; }

        public KanbanEditControl(DevExpress.XtraGrid.Views.Tile.TileView ownerView, DataTable employees, DataTable members, DataTable checkList) {
            InitializeComponent();
            this.OwnerView = ownerView;
            this.comboBoxEdit1.Properties.Items.AddRange(typeof(TaskLabel).GetEnumValues());
            this.Employees = employees;
            this.Members = members;
            this.Checklist = checkList;
            this.gridControl1.DataSource = Checklist;
            this.memberTiles.AnimateArrival = false;
            this.memberTiles.ItemClick += tileControl1_ItemClick;
            this.VisibleChanged += (s, e) => { if(Visible) ControlShown(); };
            this.gridChecklist.CellValueChanged += gridView1_CellValueChanged;
            this.gridChecklist.RowCountChanged += (s, e) => { UpdateProgressBar(); };
        }

        void ControlShown() {
            PopulateMembers();
            UpdateProgressBar();
        }
        void PopulateMembers() {
            tileGroup.Items.Clear();
            addMemberItem.Visible = true;
            tileGroup.Items.Add(addMemberItem);

            var memberIDs = GetMemeberIDs();
            foreach(var memberId in memberIDs) {
                var bytes = Employees.Rows.Find(memberId)["Photo"];
                var item = new TileItem();
                item.Image = ByteImageConverter.FromByteArray(bytes as byte[]);
                item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                var superTip = new SuperToolTip();
                superTip.Items.AddTitle(GetEmployeeFullName(memberId));
                item.SuperTip = superTip;
                item.Tag = memberId;
                tileGroup.Items.Insert(0, item);
                addMemberItem.Visible = tileGroup.Items.Count == 5 ? false : true;
            }
        }
        void OnAddMemberMenuClick(object sender, EventArgs e) {
            string newId = (sender as DXMenuItem).Tag as string;
            var newRow = Members.NewRow();
            newRow["TaskID"] = CurrentTaskID;
            newRow["MemberID"] = newId;
            Members.Rows.Add(newRow);
            PopulateMembers();
        }
        void addMemberItem_ItemClick(object sender, TileItemEventArgs e) {
            var memberIDs = GetMemeberIDs();
            var menu = new DXPopupMenu();
            menu.MenuViewType = MenuViewType.Menu;
            for(int i = 0; i < Employees.Rows.Count; i++) {
                var row = Employees.Rows[i];
                string id = row["EmployeeID"].ToString();
                if(memberIDs.Contains(id))
                    continue;
                string fullName = GetEmployeeFullName(id);
                var memberMenuItem = new DXMenuItem(fullName, new EventHandler(OnAddMemberMenuClick)) { Tag = id };
                menu.Items.Add(memberMenuItem);
            }
            ShowPopup(menu);
        }
        void tileControl1_ItemClick(object sender, TileItemEventArgs e) {
            if(e.Item == addMemberItem)
                return;
            var menu = new DXPopupMenu();
            menu.MenuViewType = MenuViewType.Menu;
            string id = e.Item.Tag as string;
            var removeItem = new DXMenuItem("Remove from card", new EventHandler(OnRemoveItemClick)) { Tag = id };
            menu.Items.Add(removeItem);
            ShowPopup(menu);
        }
        void OnRemoveItemClick(object sender, EventArgs e) {
            var memberId = (sender as DXMenuItem).Tag as string;
            var rowsToRemove = Members.Select("TaskID = " + CurrentTaskID + "AND MemberID = " + memberId);
            foreach(var rowToRemove in rowsToRemove)
                Members.Rows.Remove(rowToRemove);
            PopulateMembers();
        }
        void ShowPopup(DXPopupMenu menu) {
            Control parentControl = memberTiles;
            Point pt = parentControl.PointToClient(Control.MousePosition);
            ((IDXDropDownControl)menu).Show(StandardMenuManager.Default, parentControl, pt);
        }
        string GetEmployeeFullName(string employeeId) {
            var row = Employees.Rows.Find(employeeId);
            return string.Format("{0} {1}", row["FirstName"], row["LastName"]);
        }
        List<string> GetMemeberIDs() {
            var memberRows = Members.Select("TaskID = " + CurrentTaskID);
            return memberRows.AsEnumerable().Select(x => x["MemberID"].ToString()).ToList();
        }
        string CurrentTaskID {
            get { return (OwnerView.GetRow(OwnerView.FocusedRowHandle) as TaskRecord).Id.ToString(); }
        }
        void gridView1_CustomRowFilter(object sender, Views.Base.RowFilterEventArgs e) {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if(dv[e.ListSourceRow]["TaskID"].ToString() == CurrentTaskID) e.Visible = true;
            else e.Visible = false;
            e.Handled = true;
        }
        void gridView1_InitNewRow(object sender, InitNewRowEventArgs e) {
            gridChecklist.SetRowCellValue(e.RowHandle, gridChecklist.Columns["TaskID"], int.Parse(CurrentTaskID));
            gridChecklist.SetRowCellValue(e.RowHandle, gridChecklist.Columns["Caption"], "New item");
            gridChecklist.SetRowCellValue(e.RowHandle, gridChecklist.Columns["Checked"], false);
        }
        void gridView1_CellValueChanged(object sender, Views.Base.CellValueChangedEventArgs e) {
            gridChecklist.UpdateCurrentRow();
            UpdateProgressBar();
        }
        void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e) {
            gridChecklist.PostEditor();
        }
        void UpdateProgressBar() {
            int count = Checklist.Select("TaskID = " + CurrentTaskID).Count(); 
            if(count == 0) {
                progressBarControl1.Properties.Maximum = 1;
                progressBarControl1.Position = 0;
            }
            else {
                progressBarControl1.Properties.Maximum = count;
                progressBarControl1.Position = Checklist.Select("TaskID = " + CurrentTaskID + " AND Checked").Count();
            }
        }
    }
}
