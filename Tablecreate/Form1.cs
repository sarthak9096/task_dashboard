using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Tablecreate
{
    public partial class Form1 : Form
    {
        int pageNumber = 0;
        int pageValue = 0;
        string headerName12 = "";
        string headerName41 = "";
        private HashSet<string> selectedValues = new HashSet<string>();
        private HashSet<string> selectedValues1 = new HashSet<string>();
        List<string> currentStatusValues = new List<string>();
        List<string> assign = new List<string>();
        static bool isListBoxVisible = false;
        private List<string> columnNames = new List<string>{
            "col01", "col11", "col21", "col31", "col41", "col61", "col81",
            "col101", "col91", "col111", "col231", "col241"};
        public Form1()
        {
            InitializeComponent();
            pageValue = 0;
            // LoadJsonData();
            UpdateHeaders();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }
        private void UpdateHeaders()
        {
            DateTime currentDate = DateTime.Now;
            int numberOfColumnsBefore = 10;
            int numberOfColumnsAfter = 20;
            for (int i = 11; i < 11 + numberOfColumnsBefore; i++)
            {
                dataGridView1.Columns[i].HeaderText = currentDate.AddDays(i - 11 - numberOfColumnsBefore).ToString("dd MMM");
            }
            for (int i = 11 + numberOfColumnsBefore; i < 11 + numberOfColumnsBefore + numberOfColumnsAfter; i++)
            {
                dataGridView1.Columns[i].HeaderText = currentDate.AddDays(i - 11 - numberOfColumnsBefore).ToString("dd MMM");
            }
        }

        private async Task LoadJsonData()
        {
            try
            {
                pictureBox1.Visible = true;

                string jsonString = "";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("username", "sarthakvarpe");
                client.DefaultRequestHeaders.Add("password", "pass123");
                client.DefaultRequestHeaders.Add("Authorization", "Basic c2FydGhha3ZhcnBlOnBhc3MxMjM=");
                var content = new StringContent("{\r\n    \"bypass_session\":true,\r\n  \"tableConfig\": {\r\n    \"properties\": {\r\n      \"tableType\": \"dynamic\",\r\n      \"tableName\": \"Timelines\",\r\n      \"numberOfRows\": \"\",\r\n      \"staticRows\": \"\",\r\n      \"printstatictable\": \"\",\r\n      \"numberOfStaticRows\": \"\",\r\n      \"numberOfColumns\": \"\",\r\n      \"tableDataSource\": \"data-source-Jira_Current_Status\",\r\n      \"columns-configuration\": [\r\n        {\r\n          \"displayOption\": \"Feature\",\r\n          \"value\": \"Feature\",\r\n          \"uuid\": \"Feature\",\r\n          \"type\": \"text\",\r\n          \"id\": \"9376c4b1-53f8-4747-b904-6e655e6dfe11\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Summary\",\r\n          \"value\": \"Summary\",\r\n          \"uuid\": \"Summary\",\r\n          \"type\": \"text\",\r\n          \"id\": \"8abe5469-8bae-484e-a2e8-1179aa0da9fb\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Assignee\",\r\n          \"value\": \"Assignee\",\r\n          \"uuid\": \"Assignee\",\r\n          \"type\": \"text\",\r\n          \"id\": \"7b3f9b81-3f05-486b-8a08-08e6f9058a02\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Support Engineer\",\r\n          \"value\": \"Support Engineer\",\r\n          \"uuid\": \"Support Engineer\",\r\n          \"type\": \"text\",\r\n          \"id\": \"2f6a872e-37f3-4b4c-b7c4-b9f5c1cdc5d5\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Current Status\",\r\n          \"value\": \"Current Status\",\r\n          \"uuid\": \"Current Status\",\r\n          \"type\": \"text\",\r\n          \"id\": \"79e23dfe-7cef-4736-b79f-284acf6c77a1\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Timeline Status\",\r\n          \"value\": \"Timeline Status\",\r\n          \"uuid\": \"Timeline Status\",\r\n          \"type\": \"text\",\r\n          \"id\": \"b8f5f58a-f827-43ac-84f1-b80888828133\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Time Estimates (Hrs)\",\r\n          \"value\": \"Dev Time Estimates (Hrs)\",\r\n          \"uuid\": \"Dev Time Estimates (Hrs)\",\r\n          \"type\": \"number\",\r\n          \"id\": \"4faf73cc-f7ae-41a9-899b-232dd4c5e191\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Time Spent (Hrs)\",\r\n          \"value\": \"Dev Time Spent (Hrs)\",\r\n          \"uuid\": \"Dev Time Spent (Hrs)\",\r\n          \"type\": \"number\",\r\n          \"id\": \"abda353d-9638-4c11-934b-3880556eb083\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Planned Start Date\",\r\n          \"value\": \"Dev Planned Start Date\",\r\n          \"uuid\": \"Dev Planned Start Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"3cd91964-817c-46e7-bf5f-664e3369bfe0\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Actual Start Date\",\r\n          \"value\": \"Dev Actual Start Date\",\r\n          \"uuid\": \"Dev Actual Start Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"7041449c-229c-43de-9a6d-d0d928cc5a70\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Planned Target Date\",\r\n          \"value\": \"Dev Planned Target Date\",\r\n          \"uuid\": \"Dev Planned Target Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"2e944434-e6e9-47f3-b4a1-d7a140abac0d\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Dev Actual Completion Date\",\r\n          \"value\": \"Dev Actual Completion Date\",\r\n          \"uuid\": \"Dev Actual Completion Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"44c0e70b-11cd-4cbc-9a6f-9157c2d7e205\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Priority\",\r\n          \"value\": \"Priority\",\r\n          \"uuid\": \"Priority\",\r\n          \"type\": \"text\",\r\n          \"id\": \"16b435c7-ef36-4d10-bc1b-e967bf709f17\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Last Comment\",\r\n          \"value\": \"Last Comment\",\r\n          \"uuid\": \"Last Comment\",\r\n          \"type\": \"text\",\r\n          \"id\": \"c62ba7a0-5a6b-47ab-af3d-6f0f7a833fb3\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Last Comment Date\",\r\n          \"value\": \"Last Comment Date\",\r\n          \"uuid\": \"Last Comment Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"5d6d2eaa-9624-4575-8626-512268a71c0b\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Last Commenter\",\r\n          \"value\": \"Last Commenter\",\r\n          \"uuid\": \"Last Commenter\",\r\n          \"type\": \"text\",\r\n          \"id\": \"adeb5d46-bf71-4759-b9c9-763d7da2df9b\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Changes Deployment Date\",\r\n          \"value\": \"Changes Deployment Date\",\r\n          \"uuid\": \"Changes Deployment Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"9e3e8642-a4ae-4e43-b85e-9783c7a00f01\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Updated\",\r\n          \"value\": \"Updated\",\r\n          \"uuid\": \"Updated\",\r\n          \"type\": \"time\",\r\n          \"id\": \"327e6bc2-e23c-428e-819e-1e0eb79a1d28\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Reasons for delay\",\r\n          \"value\": \"Reasons for delay\",\r\n          \"uuid\": \"Reasons for delay\",\r\n          \"type\": \"text\",\r\n          \"id\": \"8b3c8a18-ff04-472d-826b-0240adbd8b52\"\r\n        },\r\n        {\r\n          \"displayOption\": \"RCA\",\r\n          \"value\": \"RCA\",\r\n          \"uuid\": \"RCA\",\r\n          \"type\": \"text\",\r\n          \"id\": \"d78d9485-7cf5-44ba-ba15-2d6c3552bff3\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Fix versions\",\r\n          \"value\": \"Fix versions\",\r\n          \"uuid\": \"Fix versions\",\r\n          \"type\": \"text\",\r\n          \"id\": \"4a2990bc-1d80-47b9-bf96-d4b375835043\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Build Release Date\",\r\n          \"value\": \"Build Release Date\",\r\n          \"uuid\": \"Build Release Date\",\r\n          \"type\": \"time\",\r\n          \"id\": \"939cf0c1-c498-4e56-ad6f-cc007a5950f9\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Build Released\",\r\n          \"value\": \"Build Released\",\r\n          \"uuid\": \"Build Released\",\r\n          \"type\": \"text\",\r\n          \"id\": \"ab79d8ba-4294-49a2-8e19-568657379c00\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Key\",\r\n          \"value\": \"Key\",\r\n          \"uuid\": \"Key\",\r\n          \"type\": \"text\",\r\n          \"id\": \"4382d4a4-722c-46df-8cb9-83786164795d\"\r\n        },\r\n        {\r\n          \"displayOption\": \"Issue Type\",\r\n          \"value\": \"Issue Type\",\r\n          \"uuid\": \"Issue Type\",\r\n          \"type\": \"text\",\r\n          \"id\": \"8e77bdc1-ef9b-4c87-bc90-186bdb9bfaf3\"\r\n        }\r\n      ],\r\n      \"distinct_columns\": [],\r\n      \"live\": \"\",\r\n      \"displayWhenNoData\": \"\",\r\n      \"serialNumber\": \"\",\r\n      \"customPageSize\": \"\",\r\n      \"pageSize\": \"\",\r\n      \"checkboxGroup\": {\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\"\r\n      },\r\n      \"dataSource\": \"data-source-Jira_Current_Status\"\r\n    },\r\n    \"style\": {\r\n      \"evenBackgroundColor\": \"\",\r\n      \"oddBackgroundColor\": \"\",\r\n      \"headerFontSize\": 15,\r\n      \"bodyFontSize\": 14,\r\n      \"border\": \"\",\r\n      \"color\": \"#d0d0d0\",\r\n      \"size\": 1,\r\n      \"borderRadius\": \"\",\r\n      \"borderRadiusSize\": 5\r\n    },\r\n    \"filters\": [\r\n      {\r\n        \"column\": {\r\n          \"name\": \"Current Status\",\r\n          \"type\": \"text\"\r\n        },\r\n        \"operator\": \"equal to\",\r\n        \"values\": [\r\n          \"Reopened\",\r\n          \"Open\",\r\n          \"In Progress\"\r\n        ],\r\n        \"from\": \"\",\r\n        \"to\": \"\"\r\n      },\r\n      {\r\n        \"column\": {\r\n          \"name\": \"Assignee\",\r\n          \"type\": \"text\"\r\n        },\r\n        \"operator\": \"equal to\",\r\n        \"values\": [\r\n          \"Nandkishor Chavan\"\r\n        ],\r\n        \"from\": \"\",\r\n        \"to\": \"\"\r\n      }\r\n    ],\r\n    \"editing\": {\r\n      \"editable\": \"\",\r\n      \"addForm\": \"\",\r\n      \"updateForm\": \"\"\r\n    },\r\n    \"frequency\": {},\r\n    \"aggregate\": {}\r\n  },\r\n  \"columnsConfig\": [\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Feature\",\r\n        \"selectDataColumn\": \"Feature\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col01\",\r\n          \"editId\": \"Column 1\",\r\n          \"name\": \"Feature\",\r\n          \"width\": 170,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Feature\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 150,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Summary\",\r\n        \"selectDataColumn\": \"Summary\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col11\",\r\n          \"editId\": \"Column 2\",\r\n          \"name\": \"Summary\",\r\n          \"width\": 320,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Summary\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 300,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Assignee\",\r\n        \"selectDataColumn\": \"Assignee\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col21\",\r\n          \"editId\": \"Column 3\",\r\n          \"name\": \"Assignee\",\r\n          \"width\": 106,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Assignee\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Support Engineer\",\r\n        \"selectDataColumn\": \"Support Engineer\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col31\",\r\n          \"editId\": \"Column 4\",\r\n          \"name\": \"Support Engineer\",\r\n          \"width\": 120,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Support Engineer\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 100,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Current Status\",\r\n        \"selectDataColumn\": \"Current Status\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col41\",\r\n          \"editId\": \"Column 5\",\r\n          \"name\": \"Current Status\",\r\n          \"width\": 106,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Current Status\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Timeline Status\",\r\n        \"selectDataColumn\": \"Timeline Status\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col51\",\r\n          \"editId\": \"Column 6\",\r\n          \"name\": \"Timeline Status\",\r\n          \"width\": 120,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Timeline Status\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 100,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Time Estimates (Hrs)\",\r\n        \"selectDataColumn\": \"Dev Time Estimates (Hrs)\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"number\",\r\n        \"displayName\": {\r\n          \"id\": \"col61\",\r\n          \"editId\": \"Column 7\",\r\n          \"name\": \"Dev Time Estimates (Hrs)\",\r\n          \"width\": 75,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Time Estimates (Hrs)\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 50,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Time Spent (Hrs)\",\r\n        \"selectDataColumn\": \"Dev Time Spent (Hrs)\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"number\",\r\n        \"displayName\": {\r\n          \"id\": \"col71\",\r\n          \"editId\": \"Column 8\",\r\n          \"name\": \"Dev Time Spent (Hrs)\",\r\n          \"width\": 75,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Time Spent (Hrs)\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 50,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Planned Start Date\",\r\n        \"selectDataColumn\": \"Dev Planned Start Date\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col81\",\r\n          \"editId\": \"Column 9\",\r\n          \"name\": \"Dev Planned Start Date\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Planned Start Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Actual Start Date\",\r\n        \"selectDataColumn\": \"Dev Actual Start Date\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col91\",\r\n          \"editId\": \"Column 10\",\r\n          \"name\": \"Dev Actual Start Date\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Actual Start Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Planned Target Date\",\r\n        \"selectDataColumn\": \"Dev Planned Target Date\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col101\",\r\n          \"editId\": \"Column 11\",\r\n          \"name\": \"Dev Planned Target Date\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Planned Target Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Dev Actual Completion Date\",\r\n        \"selectDataColumn\": \"Dev Actual Completion Date\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col111\",\r\n          \"editId\": \"Column 12\",\r\n          \"name\": \"Dev Actual Completion Date\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Dev Actual Completion Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Priority\",\r\n        \"selectDataColumn\": \"Priority\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col121\",\r\n          \"editId\": \"Column 13\",\r\n          \"name\": \"Priority\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Priority\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Last Comment\",\r\n        \"selectDataColumn\": \"Last Comment\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col131\",\r\n          \"editId\": \"Column 14\",\r\n          \"name\": \"Last Comment\",\r\n          \"width\": 320,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Last Comment\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 300,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Last Comment Date\",\r\n        \"selectDataColumn\": \"Last Comment Date\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col141\",\r\n          \"editId\": \"Column 15\",\r\n          \"name\": \"Last Comment Date\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Last Comment Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Last Commenter\",\r\n        \"selectDataColumn\": \"Last Commenter\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col151\",\r\n          \"editId\": \"Column 16\",\r\n          \"name\": \"Last Commenter\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Last Commenter\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Changes Deployment Date\",\r\n        \"selectDataColumn\": \"Changes Deployment Date\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col161\",\r\n          \"editId\": \"Column 17\",\r\n          \"name\": \"Changes Deployment Date\",\r\n          \"width\": 140,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Changes Deployment Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 120,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Updated\",\r\n        \"selectDataColumn\": \"Updated\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col171\",\r\n          \"editId\": \"Column 18\",\r\n          \"name\": \"Updated\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Updated\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Reasons for delay\",\r\n        \"selectDataColumn\": \"Reasons for delay\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col181\",\r\n          \"editId\": \"Column 19\",\r\n          \"name\": \"Reasons for delay\",\r\n          \"width\": 520,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Reasons for delay\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 500,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"RCA\",\r\n        \"selectDataColumn\": \"RCA\",\r\n        \"aggregator\": \"\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"df\": \"\",\r\n        \"tf\": \"\",\r\n        \"formula\": \"\",\r\n        \"deviation\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectCSumCol\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"derived_value\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col191\",\r\n          \"editId\": \"Column 20\",\r\n          \"name\": \"RCA\",\r\n          \"width\": 520,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"RCA\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": true,\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"columnWidth\": 500,\r\n        \"conFormatting\": false,\r\n        \"border\": \"\",\r\n        \"borderColor\": \"#000000\",\r\n        \"size\": \"1\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Fix versions\",\r\n        \"selectDataColumn\": \"Fix versions\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col201\",\r\n          \"editId\": \"Column 21\",\r\n          \"name\": \"Fix versions\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Fix versions\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Build Release Date\",\r\n        \"selectDataColumn\": \"Build Release Date\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"time\",\r\n        \"displayName\": {\r\n          \"id\": \"col211\",\r\n          \"editId\": \"Column 22\",\r\n          \"name\": \"Build Release Date\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Build Release Date\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Build Released\",\r\n        \"selectDataColumn\": \"Build Released\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col221\",\r\n          \"editId\": \"Column 23\",\r\n          \"name\": \"Build Released\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Build Released\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Key\",\r\n        \"selectDataColumn\": \"Key\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col231\",\r\n          \"editId\": \"Column 24\",\r\n          \"name\": \"Key\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Key\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    },\r\n    {\r\n      \"properties\": {\r\n        \"columnType\": \"datacolumn\",\r\n        \"colName\": \"Issue Type\",\r\n        \"selectDataColumn\": \"Issue Type\",\r\n        \"operator\": \"\",\r\n        \"precision\": \"\",\r\n        \"selectColumn1\": \"\",\r\n        \"selectColumn2\": \"\",\r\n        \"value\": \"\",\r\n        \"summary\": \"\",\r\n        \"total\": \"\",\r\n        \"max\": \"\",\r\n        \"min\": \"\",\r\n        \"avg\": \"\",\r\n        \"mergeSimilarValueCell\": \"\",\r\n        \"hideColumn\": \"\",\r\n        \"dataColumnType\": \"text\",\r\n        \"displayName\": {\r\n          \"id\": \"col241\",\r\n          \"editId\": \"Column 25\",\r\n          \"name\": \"Issue Type\",\r\n          \"width\": 115,\r\n          \"height\": 56\r\n        },\r\n        \"columnName\": \"Issue Type\",\r\n        \"round\": false\r\n      },\r\n      \"style\": {\r\n        \"columnFormatting\": false,\r\n        \"matchWith\": \"\",\r\n        \"value\": \"\",\r\n        \"dataColumn\": \"\",\r\n        \"aggregator\": \"\",\r\n        \"replaceBy\": \"\",\r\n        \"backgroundColor\": \"\",\r\n        \"color\": \"\",\r\n        \"border\": false,\r\n        \"size\": \"1\",\r\n        \"borderColor\": \"#000000\",\r\n        \"borderRadius\": false,\r\n        \"borderRadiusSize\": \"0\",\r\n        \"conFormatting\": false,\r\n        \"columnWidth\": \"\",\r\n        \"conditions\": []\r\n      }\r\n    }\r\n  ],\r\n  \"columnsToDisplay\": [\r\n    {\r\n      \"id\": \"col01\",\r\n      \"editId\": \"Column 1\",\r\n      \"name\": \"Feature\",\r\n      \"width\": 170,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col11\",\r\n      \"editId\": \"Column 2\",\r\n      \"name\": \"Summary\",\r\n      \"width\": 320,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col21\",\r\n      \"editId\": \"Column 3\",\r\n      \"name\": \"Assignee\",\r\n      \"width\": 106,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col31\",\r\n      \"editId\": \"Column 4\",\r\n      \"name\": \"Support Engineer\",\r\n      \"width\": 120,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col41\",\r\n      \"editId\": \"Column 5\",\r\n      \"name\": \"Current Status\",\r\n      \"width\": 106,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col51\",\r\n      \"editId\": \"Column 6\",\r\n      \"name\": \"Timeline Status\",\r\n      \"width\": 120,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col61\",\r\n      \"editId\": \"Column 7\",\r\n      \"name\": \"Dev Time Estimates (Hrs)\",\r\n      \"width\": 75,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col71\",\r\n      \"editId\": \"Column 8\",\r\n      \"name\": \"Dev Time Spent (Hrs)\",\r\n      \"width\": 75,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col81\",\r\n      \"editId\": \"Column 9\",\r\n      \"name\": \"Dev Planned Start Date\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col91\",\r\n      \"editId\": \"Column 10\",\r\n      \"name\": \"Dev Actual Start Date\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col101\",\r\n      \"editId\": \"Column 11\",\r\n      \"name\": \"Dev Planned Target Date\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col111\",\r\n      \"editId\": \"Column 12\",\r\n      \"name\": \"Dev Actual Completion Date\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col121\",\r\n      \"editId\": \"Column 13\",\r\n      \"name\": \"Priority\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col131\",\r\n      \"editId\": \"Column 14\",\r\n      \"name\": \"Last Comment\",\r\n      \"width\": 320,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col141\",\r\n      \"editId\": \"Column 15\",\r\n      \"name\": \"Last Comment Date\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col151\",\r\n      \"editId\": \"Column 16\",\r\n      \"name\": \"Last Commenter\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col161\",\r\n      \"editId\": \"Column 17\",\r\n      \"name\": \"Changes Deployment Date\",\r\n      \"width\": 140,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col171\",\r\n      \"editId\": \"Column 18\",\r\n      \"name\": \"Updated\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col181\",\r\n      \"editId\": \"Column 19\",\r\n      \"name\": \"Reasons for delay\",\r\n      \"width\": 520,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col191\",\r\n      \"editId\": \"Column 20\",\r\n      \"name\": \"RCA\",\r\n      \"width\": 520,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col201\",\r\n      \"editId\": \"Column 21\",\r\n      \"name\": \"Fix versions\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col211\",\r\n      \"editId\": \"Column 22\",\r\n      \"name\": \"Build Release Date\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col221\",\r\n      \"editId\": \"Column 23\",\r\n      \"name\": \"Build Released\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col231\",\r\n      \"editId\": \"Column 24\",\r\n      \"name\": \"Key\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    },\r\n    {\r\n      \"id\": \"col241\",\r\n      \"editId\": \"Column 25\",\r\n      \"name\": \"Issue Type\",\r\n      \"width\": 115,\r\n      \"height\": 56\r\n    }\r\n  ],\r\n  \"options\": {\r\n    \"pageNumber\": 0,\r\n    \"pageSize\": 25,\r\n    \"sortColumn\": {\r\n      \"name\": \"Dev Actual Start Date\",\r\n      \"direction\": \"DESC\",\r\n      \"id\": \"\"\r\n    }\r\n  },\r\n  \"pageIndex\": 0,\r\n  \"dashboard_id\": \"dashboardDesigner-1740cf70-0565-4175-a4cb-64c066322fc5\",\r\n  \"dataSource\": \"data-source-Jira_Current_Status\",\r\n  \"uuid\": \"0289fb34-5a2b-432b-9b1a-e7e48f526be9\",\r\n  \"batches\": [],\r\n  \"version\": \"1.0.0\"\r\n}", null, "application/json"); string stringContent = await content.ReadAsStringAsync();
                dynamic jsonObject = JsonConvert.DeserializeObject(stringContent);
                jsonObject.tableConfig.filters[0].values.Clear();
                jsonObject.tableConfig.filters[1].values.Clear();
                foreach (var value in currentStatusValues)
                {
                    jsonObject.tableConfig.filters[0].values.Add(value);
                }

                jsonObject.options.pageNumber = pageValue;
                foreach (var value in assign)
                {
                    jsonObject.tableConfig.filters[1].values.Add(value);
                }
                jsonString = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://operations.itantaanalytics.com/api/ana/designer/dynamic-table-data/");
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(responseContent);
                List<Dictionary<string, ColumnData1>> dataList1 = ConvertData(root, columnNames);
                PopulateDataGridView(dataList1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            pictureBox1.Visible = false;
        }
        private List<Dictionary<string, ColumnData1>> ConvertData(Root root, List<string> columnsToPrint)
        {
            List<Dictionary<string, ColumnData1>> dataList1 = new List<Dictionary<string, ColumnData1>>();
            foreach (var columnsDict in root.columns)
            {
                var dataRow = new Dictionary<string, ColumnData1>();
                foreach (var kvp in columnsDict)
                {
                    var columnName = kvp.Key;
                    if (columnsToPrint.Contains(columnName))
                    {
                        var columnValue = kvp.Value.value;
                        dataRow[columnName] = new ColumnData1 { value = columnValue };
                    }
                }
                dataList1.Add(dataRow);
            }
            return dataList1;
        }
        private void HighlightSpecificColumn()
        {
            DateTime currentDate = DateTime.Now;
            string targetColumnHeaderText = currentDate.ToString("dd MMM");
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText.Contains(targetColumnHeaderText))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[column.Index].Style.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void PopulateDataGridView(List<Dictionary<string, ColumnData1>> dataList1)
        {
            string headerName12 = "";
            string headerName41 = "";

            if (dataGridView1.ColumnCount > 12 && dataGridView1.ColumnCount > 41)
            {
                headerName12 = dataGridView1.Columns[11].HeaderText;
                headerName41 = dataGridView1.Columns[40].HeaderText;
            }
            List<List<string>> resultList = new List<List<string>>();
            foreach (var data in dataList1)
            {
                List<string> planePair = new List<string>();
                List<string> actualPair = new List<string>();
                string plane_start = "";
                string actual_start = "";
                string plane_end = "";
                string actual_end = "";
                foreach (var kvp in data)
                {
                    if (kvp.Key == "col91")
                    {
                        if (kvp.Value.value == "-")
                        {
                            actual_start = "";
                        }
                        else
                        {
                            actual_start = DateTime.ParseExact(kvp.Value.value, "dd-MMM-yy HH:mm", System.Globalization.CultureInfo.InvariantCulture).ToString("dd MMM");
                        }

                    }
                    else if (kvp.Key == "col111")
                    {
                        if (kvp.Value.value == "-")
                        {
                            actual_end = "";
                        }
                        else
                        {
                            actual_end = DateTime.ParseExact(kvp.Value.value, "dd-MMM-yy HH:mm", System.Globalization.CultureInfo.InvariantCulture).ToString("dd MMM");
                        }

                    }
                }
                actualPair.Add(actual_start);
                actualPair.Add(actual_end);
                resultList.Add(actualPair);
                dataGridView1.Rows.Clear();
            }
            foreach (var rowData in dataList1)
            {
                DataGridViewRow firstRow = new DataGridViewRow();
                for (int i = 0; i < 12; i++)
                {
                    var columnName = columnNames[i];
                    if (rowData.TryGetValue(columnName, out var columnData))
                    {
                        if (i == 10 || i == 11)
                        {
                            firstRow.Cells.Add(new DataGridViewTextBoxCell { Value = columnData.value });

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    var columnName = columnNames[i];
                    if (rowData.TryGetValue(columnName, out var columnData))
                    {
                        if (i == 6 || i == 7)
                        {
                            continue;
                        }
                        firstRow.Cells.Add(new DataGridViewTextBoxCell { Value = columnData.value });

                    }
                    else
                    {
                        firstRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    }
                }
                dataGridView1.Rows.Add(firstRow);
            }
            //start colouring
            if (dataGridView1.ColumnCount > 12 && dataGridView1.ColumnCount >= 35)
            {
                headerName12 = dataGridView1.Columns[11].HeaderText;
                headerName41 = dataGridView1.Columns[40].HeaderText;
            }

            int rowCount = dataGridView1.Rows.Count;
            DateTime header12Date = DateTime.ParseExact(headerName12 + " " + DateTime.Now.Year, "dd MMM yyyy", CultureInfo.InvariantCulture);
            DateTime header41Date = DateTime.ParseExact(headerName41 + " " + DateTime.Now.Year, "dd MMM yyyy", CultureInfo.InvariantCulture);
            for (int i = 0; i < rowCount && i < resultList.Count; i++)
            {
                List<string> currentPair = resultList[i];
                bool startColoring = false;
                string startColumnHeaderText = currentPair[0];
                string endColumnHeaderText = currentPair[1];
                if (string.IsNullOrEmpty(currentPair[1]) || string.IsNullOrEmpty(currentPair[0]))
                {
                    Console.WriteLine("first value" + startColumnHeaderText + "second value" + endColumnHeaderText);
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[cell.ColumnIndex];

                        if (string.IsNullOrEmpty(currentPair[1]))
                        {
                            if (startColoring)
                            {
                                cell.Style.BackColor = Color.Green;
                            }
                            string currentHeaderText = column.HeaderText;
                            if (currentHeaderText == startColumnHeaderText)
                            {
                                startColoring = true;
                            }

                        }
                    }

                }
                else
                {
                    // Console.WriteLine(startColumnHeaderText + "kk " + endColumnHeaderText);
                    bool reverseColoring = string.Compare(endColumnHeaderText, startColumnHeaderText) < 0;
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {

                        DataGridViewColumn column = dataGridView1.Columns[cell.ColumnIndex];
                        string currentHeaderText = column.HeaderText;
                        if (currentHeaderText == startColumnHeaderText)
                        {
                            startColoring = true;
                        }
                        if (startColoring)
                        {
                            cell.Style.BackColor = Color.Green;
                        }
                        if (string.IsNullOrEmpty(endColumnHeaderText))
                        {
                            break;
                        }
                        DateTime dateTime1 = DateTime.ParseExact(startColumnHeaderText + " " + DateTime.Now.Year, "dd MMM yyyy", CultureInfo.InvariantCulture);
                        DateTime dateTime2 = DateTime.ParseExact(endColumnHeaderText + " " + DateTime.Now.Year, "dd MMM yyyy", CultureInfo.InvariantCulture);

                        int result2 = DateTime.Compare(dateTime1, header12Date);
                        int result3 = DateTime.Compare(dateTime2, header12Date);
                        
                        if (result2 < 0 && result3 > 0)
                        {
                            startColoring = true;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                for (int m = 0; m < 11; m++)
                                {
                                    row.Cells[m].Style.BackColor = SystemColors.Window;
                                }
                            }
                        }

                        int result = DateTime.Compare(dateTime1, dateTime2);
                        if (result > 0 || currentHeaderText == endColumnHeaderText)
                        {
                            break;
                        }
                    }


                }
                HighlightSpecificColumn();
            }

        }
        //end Colouring
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }



        private void label2_Click(object sender, EventArgs e)
        {
            string todayDate = DateTime.Now.ToString("MMMM dd, yyyy");
            label2.Text = todayDate;
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            if (pageValue > 0)
            {
                dataGridView1.Rows.Clear();
                pageValue--;
                button5.Text = pageValue.ToString();

                LoadJsonData();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            pageValue++;
            button5.Text = pageValue.ToString();

            LoadJsonData();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Blue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private async void login_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            string plainText = Username.Text;
            string data = Password.Text;
            string jsonString = "";
            String Upresent = "present";
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            string path = @"D:\localgitrepo\star_itantaanalytics_com.crt";
            var collection = new X509Certificate2Collection();
            collection.Import(path);
            var certificate = collection[0];
            var output = "";
            using (RSA csp = (RSA)certificate.PublicKey.Key)
            {
                byte[] bytesEncrypted = csp.Encrypt(byteData, RSAEncryptionPadding.Pkcs1);
                output = Convert.ToBase64String(bytesEncrypted);

                string jsonString1 = "";
                string encryptedData = output;

                var client = new HttpClient();
                var content = new StringContent("{\r\n    \r\n  \"username\": \"planeText\",\r\n  \"password\": \"Ud84Q0NBit2ShU5cBy1AntlnCVKEulWlFJ3afhUJao5fYhD4HuaWzmpOasrd5OiZfzKnr2zHAj7DCVJGxtrhlvZNEFbocGfYyB+AJ/De1nzJdyq992rlonJJSrRlMLyf1q/h0TG5RQrg6+x7210NObDKuWjaJ1umCC2w1JDozzhJGRPAHdNps7qqZRksPRufOdZcFZDR6/JK3XCcuSmu9GOq+K31Wu9FcxLQcinQWfpyYdeIZkPb7f/JFPA/GWo5fzrwAAOv6Pan1GcnG13zPg4XjV1SaeQ/B07MCBVktzqiSl67WLGJdob3QAAK3W+rylhugng67wVXKGFd+ccKjg==\"\r\n}", null, "application/json");
                string stringContent12 = await content.ReadAsStringAsync();
                dynamic jsonObject = JsonConvert.DeserializeObject(stringContent12);
                jsonObject.password = encryptedData;
                jsonObject.username = plainText;
                jsonString1 = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://operations.itantaanalytics.com/api/ana/v1/users/login/");
                request.Content = new StringContent(jsonString1, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Upresent = "present";
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Upresent ="Not authorized ";
                }
                else
                {
                    Upresent = "Not authorized ";
                }
                if (Upresent == "present")
                {
                    pictureBox1.Visible = false;
                    groupBox1.Visible = false;
                    Username.Visible = false;
                    Password.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    login.Visible = false;
                    dataGridView1.Visible = true;
                    button9.Visible = true;
                    label1.Visible = true;
                    button3.Visible = true;
                    label2.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = true;
                    label5.Visible = true;
                    LoadJsonData();

                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }


           
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            Options.Items.Clear();
            isListBoxVisible = !isListBoxVisible;
            Options.Visible = isListBoxVisible;
            Options.Items.Clear();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://operations.itantaanalytics.com/api/ana/designer/datasources/unique_column_values/");

            var content = new StringContent("{\r\n    \"bypass_session\":true,\r\n  \"column\": \"Current Status\",\r\n  \"filters\": [],\r\n  \"dataSource\": \"data-source-Jira_Current_Status\",\r\n  \"dataSources\": [\r\n    \"data-source-Jira_Current_Status\"\r\n  ]\r\n\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseContent2 = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<EmployeeNames>(responseContent2);
            Options.Items.Clear();
            foreach (var value in responseObject.UniqueValues)
            {
                Options.Items.Add(value);
            }

        }
        private async void button8_Click(object sender, EventArgs e)
        {
            List.Items.Clear();
            isListBoxVisible = !isListBoxVisible;
            List.Visible = isListBoxVisible;

            List.Items.Clear();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://operations.itantaanalytics.com/api/ana/designer/datasources/unique_column_values/");
            //request.Headers.Add("username", "sarthakvarpe");
           // request.Headers.Add("password", "pass123");
           // request.Headers.Add("Authorization", "Basic c2FydGhha3ZhcnBlOnBhc3MxMjM=");
            var content = new StringContent("{\r\n    \"bypass_session\":true,\r\n  \"column\": \"Assignee\",\r\n  \"filters\": [],\r\n  \"dataSource\": \"data-source-Jira_Current_Status\",\r\n  \"dataSources\": [\r\n    \"data-source-Jira_Current_Status\"\r\n  ]\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseContent1 = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<EmployeeNames>(responseContent1);
            foreach (var value in responseObject.UniqueValues)
            {
                List.Items.Add(value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pageValue = 0;
            button5.Text = pageValue.ToString();
            dataGridView1.Rows.Clear();
            currentStatusValues.Clear();
            currentStatusValues.AddRange(selectedValues1);
            assign.Clear();
            assign.AddRange(selectedValues);
            LoadJsonData();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            if (selectedValues == null)
            {
                selectedValues = new HashSet<string>();
            }
            else
            {
                selectedValues.Clear();
            }

            foreach (var item in listBox.SelectedItems)
            {
                selectedValues.Add(item.ToString());
            }
        }
        private void Options_SelectedIndexChanged(object sender, EventArgs e)
        {

            Options.Visible = true;
            ListBox listBox1 = (ListBox)sender;

            if (selectedValues1 == null)
            {
                selectedValues1 = new HashSet<string>();
            }
            else
            {
                selectedValues1.Clear();
            }


            foreach (var item in listBox1.SelectedItems)
            {
                selectedValues1.Add(item.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedValues.Clear();
            selectedValues1.Clear();
        }
    }
}