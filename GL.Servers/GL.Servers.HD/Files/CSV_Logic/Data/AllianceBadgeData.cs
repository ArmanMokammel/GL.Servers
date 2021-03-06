namespace GL.Servers.HD.Files.CSV_Logic.Data
{
	using GL.Servers.Files.CSV_Reader;
	using GL.Servers.HD.Files.CSV_Helpers;

    internal class AllianceBadgeData : Data
    {
		/// <summary>
        /// Initializes a new instance of the <see cref="AllianceBadgeData"/> class.
        /// </summary>
        /// <param name="Row">The row.</param>
        /// <param name="DataTable">The data table.</param>
        public AllianceBadgeData(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.Load(this, this.GetType(), Row);
        }

        public string IconSWF
        {
            get; set;
        }

        public string IconExportName
        {
            get; set;
        }

        public string IconLayer0
        {
            get; set;
        }

        public string IconLayer1
        {
            get; set;
        }

        public string IconLayer2
        {
            get; set;
        }
    }
}
