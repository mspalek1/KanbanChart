using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DevExpress.XtraGrid.Demos {
    public class KanbanHelper {
        public static BindingList<TaskRecord> LoadTasks() {
            string file = FilesHelper.FindingFileName(Application.StartupPath, "Data\\KanbanModuleData\\KanbanTasks.xml");
            var tasks = new BindingList<TaskRecord>();
            using(var reader = new StreamReader(file)) {
                XmlSerializer deserializer = new XmlSerializer(typeof(TaskList), new XmlRootAttribute("DocumentElement"));
                var taskList = (TaskList)deserializer.Deserialize(reader);
                tasks = taskList.List;
            }
            return tasks;
        }
        public static DataTable LoadChecklist() {
            string file = FilesHelper.FindingFileName(Application.StartupPath, "Data\\KanbanModuleData\\KanbanChecklist.xml");
            var checklist = new DataTable();
            checklist.TableName = "TaskChecklist";
            checklist.Columns.Add("TaskID", typeof(Int32));
            checklist.Columns.Add("Caption", typeof(String));
            checklist.Columns.Add("Checked", typeof(Boolean));
            if(!String.IsNullOrEmpty(file) && System.IO.File.Exists(file)) {
                checklist.ReadXml(file);
            }
            return checklist;
        }
        public static DataTable LoadMembers() {
            string file = FilesHelper.FindingFileName(Application.StartupPath, "Data\\KanbanModuleData\\KanbanMembers.xml");
            var members = new DataTable();
            members.TableName = "TaskMembers";
            members.Columns.Add("TaskID", typeof(Int32));
            members.Columns.Add("MemberID", typeof(Int32));
            if(!String.IsNullOrEmpty(file) && System.IO.File.Exists(file)) {
                members.ReadXml(file);
            }
            return members;
        }
        public static DataTable LoadEmployees() { 
            string DBFileName = string.Empty;
            string connectionString = string.Empty;
            DBFileName = FilesHelper.FindingFileName(Application.StartupPath, "Data\\nwind.mdb");
            if(String.IsNullOrEmpty(DBFileName))
                return null;
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
            var table = new DataTable();
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Employees", connectionString);
            oleDbDataAdapter.Fill(table);
            table.TableName = "Employees";
            table.PrimaryKey = new DataColumn[] { table.Columns["EmployeeID"] };
            return table;
        }
        public static void ProcessMembersPhoto(DataTable employees) {
            for(int i = 0; i < employees.Rows.Count; i++) {
                var row = employees.Rows[i];
                var bytes = row["Photo"];
                var fullImage = ByteImageConverter.FromByteArray(bytes as byte[]);

                var size = new Size(40, 40);
                float scaleX = ((float)size.Width) / fullImage.Width;
                float scaleY = ((float)size.Height) / fullImage.Height;
                float scale = scaleX > scaleY ? scaleX : scaleY;

                var resizedImage = new Bitmap(size.Width, size.Height);
                using(Graphics g = Graphics.FromImage(resizedImage)) {
                    size = new Size(
                        (int)(fullImage.Width * scale + 0.5f),
                        (int)(fullImage.Height * scale + 0.5f));
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(fullImage, new Rectangle(Point.Empty, size));
                }
                var opt = new PictureEditOptionsMask(null);
                var img = PictureMaskHelper.CreateCircleMaskImage(resizedImage, opt);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                var result = ms.ToArray();
                ms.Close();
                row["Photo"] = result;
            }
        }
        public static void AddEmptyItem(IList<TaskRecord> table, TaskStatus status) {
            var row = table.FirstOrDefault(x => x.Status == status);
            if(row == null) {
                var emptyRow = CreateNewTask();
                emptyRow.Id = -1;
                emptyRow.Status = status;
                table.Add(emptyRow);
            }
        }
        public static void RemoveEmptyItem(IList<TaskRecord> table, TaskStatus status) {
            var row = table.FirstOrDefault(x => x.IsEmpty && x.Status == status);
            if(row != null)
                table.Remove(row);
        }
        public static TaskRecord CreateNewTask() {
            return new TaskRecord();
        }
        public static Image CreateCheckBadge(Color color) {
            var assembly = typeof(KanbanHelper).Assembly;
            SvgBitmap svgBitmap;
            using(var stream = assembly.GetManifestResourceStream("DevExpress.XtraGrid.Demos.Images.CheckImage.svg")) {
                svgBitmap = SvgBitmap.FromStream(stream);
            }
            if(svgBitmap == null) return null;
            var pallet = new SvgPalette();
            pallet.Colors.Add(new SvgColor("Black", color));
            return svgBitmap.Render(pallet);
        }
    }

    public enum TaskStatus { ToDo, Planned, Doing, Testing, Done }
    public enum TaskLabel { None, Red, Yellow, Green }

    public class TaskRecord  {
        public TaskRecord() {
            Label = TaskLabel.None;
        }
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        [XmlIgnore]
        public TaskStatus Status { get; set; }
        [XmlIgnore]
        public TaskLabel Label { get; set; }
        public bool IsEmpty {
            get { return Id == -1; }
        }
        [XmlElement("Status")]
        public int StatusCore {
            get { return 0; }
            set { Status = (TaskStatus)value; }
        }
        [XmlElement("Label")]
        public int LabelCore {
            get { return 0; }
            set { Label = (TaskLabel)value; }
        }
    }

    [XmlRoot("DocumentElement")]
    public class TaskList {
        public TaskList() {
            List = new BindingList<TaskRecord>();
        }
        [XmlElement("Tasks")]
        public BindingList<TaskRecord> List { get; set; }
    }
}
