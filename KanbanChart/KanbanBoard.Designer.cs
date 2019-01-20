namespace DevExpress.XtraGrid.Demos {
    partial class KanbanBoard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KanbanBoard));
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colCaption = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colProgress = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colStatus = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colMembers = new DevExpress.XtraGrid.Columns.TileViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).BeginInit();
            this.SuspendLayout();
            // 
            // colCaption
            // 
            this.colCaption.Caption = "Caption";
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Label";
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 3;
            // 
            // colProgress
            // 
            this.colProgress.Caption = "Progress";
            this.colProgress.FieldName = "Progress";
            this.colProgress.Name = "colProgress";
            this.colProgress.Visible = true;
            this.colProgress.VisibleIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.tileView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(577, 421);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView});
            // 
            // tileView
            // 
            this.tileView.Appearance.EmptySpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tileView.Appearance.EmptySpace.Options.UseBackColor = true;
            this.tileView.Appearance.GroupText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileView.Appearance.GroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(128)))));
            this.tileView.Appearance.GroupText.Options.UseFont = true;
            this.tileView.Appearance.GroupText.Options.UseForeColor = true;
            this.tileView.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileView.Appearance.ItemNormal.BorderColor = System.Drawing.Color.Gainsboro;
            this.tileView.Appearance.ItemNormal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileView.Appearance.ItemNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.tileView.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView.Appearance.ItemNormal.Options.UseBorderColor = true;
            this.tileView.Appearance.ItemNormal.Options.UseFont = true;
            this.tileView.Appearance.ItemNormal.Options.UseForeColor = true;
            this.tileView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colCaption,
            this.colMembers,
            this.colLabel,
            this.colDescription,
            this.colProgress});
            this.tileView.ColumnSet.GroupColumn = this.colStatus;
            this.tileView.GridControl = this.gridControl;
            this.tileView.Name = "tileView";
            this.tileView.OptionsBehavior.AllowSmoothScrolling = true;
            this.tileView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Tile.TileViewEditingMode.EditForm;
            this.tileView.OptionsDragDrop.AllowDrag = true;
            this.tileView.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Nothing;
            this.tileView.OptionsEditForm.PopupEditFormWidth = 500;
            this.tileView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.tileView.OptionsFind.AllowFindPanel = false;
            this.tileView.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tileView.OptionsTiles.IndentBetweenGroups = 45;
            this.tileView.OptionsTiles.IndentBetweenItems = 10;
            this.tileView.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(10);
            this.tileView.OptionsTiles.ItemSize = new System.Drawing.Size(256, 100);
            this.tileView.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            this.tileView.OptionsTiles.Padding = new System.Windows.Forms.Padding(25);
            this.tileView.OptionsTiles.RowCount = 2;
            this.tileView.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            this.tileView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStatus, DevExpress.Data.ColumnSortOrder.Ascending)});
            tileViewItemElement1.Column = this.colCaption;
            tileViewItemElement1.Text = "colCaption";
            tileViewItemElement2.Column = this.colDescription;
            tileViewItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.ImageOptions.ImageSize = new System.Drawing.Size(16, 16);
            tileViewItemElement2.Text = "colDescription";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement2.TextVisible = false;
            tileViewItemElement3.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            tileViewItemElement3.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement3.Column = this.colLabel;
            tileViewItemElement3.StretchVertical = true;
            tileViewItemElement3.Text = "colLabel";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(-9, 0);
            tileViewItemElement3.TextVisible = false;
            tileViewItemElement3.Width = 4;
            tileViewItemElement4.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            tileViewItemElement4.AnchorElementIndex = 1;
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Column = this.colProgress;
            tileViewItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileViewItemElement4.ImageOptions.ImageToTextIndent = 3;
            tileViewItemElement4.ImageVisible = false;
            tileViewItemElement4.Text = "colProgress";
            this.tileView.TileTemplate.Add(tileViewItemElement1);
            this.tileView.TileTemplate.Add(tileViewItemElement2);
            this.tileView.TileTemplate.Add(tileViewItemElement3);
            this.tileView.TileTemplate.Add(tileViewItemElement4);
            this.tileView.EditFormShowing += new DevExpress.XtraGrid.Views.Grid.EditFormShowingEventHandler(this.tileView_EditFormShowing);
            this.tileView.BeforeItemDrag += new DevExpress.XtraGrid.Views.Tile.TileViewBeforeItemDragEventHandler(this.tileView_BeforeItemDrag);
            this.tileView.ItemDrop += new DevExpress.XtraGrid.Views.Tile.TileViewItemDropEventHandler(this.tileView_ItemDrop);
            this.tileView.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileView_ItemClick);
            this.tileView.ItemCustomize += new DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventHandler(this.tileView_ItemCustomize);
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            // 
            // colMembers
            // 
            this.colMembers.Caption = "Members";
            this.colMembers.FieldName = "Members";
            this.colMembers.Name = "colMembers";
            this.colMembers.Visible = true;
            this.colMembers.VisibleIndex = 2;
            // 
            // KanbanBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "KanbanBoard";
            this.Size = new System.Drawing.Size(577, 421);
            this.Load += new System.EventHandler(this.KanbanBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl gridControl;
        private Views.Tile.TileView tileView;
        private Columns.TileViewColumn colStatus;
        private Columns.TileViewColumn colCaption;
        private Columns.TileViewColumn colMembers;
        private Columns.TileViewColumn colLabel;
        private Columns.TileViewColumn colDescription;
        private Columns.TileViewColumn colProgress;
    }
}
