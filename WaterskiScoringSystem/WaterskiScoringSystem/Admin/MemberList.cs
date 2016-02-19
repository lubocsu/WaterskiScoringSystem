﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WaterskiScoringSystem.Common;
using WaterskiScoringSystem.Admin;
using WaterskiScoringSystem.Tools;

namespace WaterskiScoringSystem.Admin {
    public partial class MemberList : Form {
        private String mySanctionNum;
        private String mySortCommand;
        private String myFilterCommand;
        private int myViewIdx;

        private DataTable myMemberListDataTable;

        private SortDialogForm sortDialogForm;
        private FilterDialogForm filterDialogForm;
        private EditMember myEditMemberDialog;

        private SqlCeCommand mySqlStmt = null;
        private SqlCeConnection myDbConn = null;

        public MemberList() {
            InitializeComponent();
        }

        private void MemberList_Load( object sender, EventArgs e ) {
            if ( Properties.Settings.Default.MemberList_Width > 0 ) {
                this.Width = Properties.Settings.Default.MemberList_Width;
            }
            if ( Properties.Settings.Default.MemberList_Height > 0 ) {
                this.Height = Properties.Settings.Default.MemberList_Height;
            }
            if ( Properties.Settings.Default.MemberList_Location.X > 0
                && Properties.Settings.Default.MemberList_Location.Y > 0 ) {
                this.Location = Properties.Settings.Default.MemberList_Location;
            }

            mySanctionNum = Properties.Settings.Default.AppSanctionNum;
            if ( mySanctionNum == null ) {
                mySanctionNum = "";
            } else {
                if ( mySanctionNum.Length < 6 ) {
                    mySanctionNum = "";
                }
            }

            myDbConn = new global::System.Data.SqlServerCe.SqlCeConnection();
            myDbConn.ConnectionString = Properties.Settings.Default.waterskiConnectionStringApp;

            myEditMemberDialog = new EditMember();

            sortDialogForm = new SortDialogForm();
            sortDialogForm.ColumnList = dataGridView.Columns;

            filterDialogForm = new Common.FilterDialogForm();
            filterDialogForm.ColumnList = dataGridView.Columns;

            myMemberListDataTable = getMemberList();
            myViewIdx = 0;
            loadDataGridView();
        }

        private void MemberList_FormClosed( object sender, FormClosedEventArgs e ) {
            if ( this.WindowState == FormWindowState.Normal ) {
                Properties.Settings.Default.MemberList_Width = this.Size.Width;
                Properties.Settings.Default.MemberList_Height = this.Size.Height;
                Properties.Settings.Default.MemberList_Location = this.Location;
            }
        }

        private void dataGridView_DataError( object sender, DataGridViewDataErrorEventArgs e ) {
            MessageBox.Show( "DataGridView_DataError occurred. \n Context: " + e.Context.ToString()
                + "\n Exception Message: " + e.Exception.Message );
            if ( ( e.Exception ) is ConstraintException ) {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                e.ThrowException = false;
            }
        }

        private void loadDataGridView() {
            //Retrieve data for current tournament
            //Used for initial load and to refresh data after updates
            winStatusMsg.Text = "Retrieving members";
            Cursor.Current = Cursors.WaitCursor;
            int curRowIdx = myViewIdx;

            dataGridView.Rows.Clear();
            myMemberListDataTable.DefaultView.Sort = mySortCommand;
            myMemberListDataTable.DefaultView.RowFilter = myFilterCommand;
            DataTable curDataTable = myMemberListDataTable.DefaultView.ToTable();

            if ( curDataTable.Rows.Count > 0 ) {
                DataGridViewRow curViewRow;
                int curViewIdx = 0;
                foreach ( DataRow curDataRow in curDataTable.Rows ) {
                    winStatusMsg.Text = "Loading information for " + (String)curDataRow["FirstName"] + " " + (String)curDataRow["LastName"];

                    curViewIdx = dataGridView.Rows.Add();
                    curViewRow = dataGridView.Rows[curViewIdx];

                    curViewRow.Cells["MemberId"].Value = (String)curDataRow["MemberId"];
                    curViewRow.Cells["FirstName"].Value = (String)curDataRow["FirstName"];
                    curViewRow.Cells["LastName"].Value = (String)curDataRow["LastName"];
                    try {
                        curViewRow.Cells["City"].Value = (String)curDataRow["City"];
                    } catch {
                        curViewRow.Cells["City"].Value = "";
                    }
                    try {
                        curViewRow.Cells["State"].Value = (String)curDataRow["State"];
                    } catch {
                        curViewRow.Cells["State"].Value = "";
                    }
                    try {
                        curViewRow.Cells["Federation"].Value = (String)curDataRow["Federation"];
                    } catch {
                        curViewRow.Cells["Federation"].Value = "";
                    }
                    try {
                        curViewRow.Cells["SkiYearAge"].Value = ((Byte)curDataRow["SkiYearAge"]).ToString();
                    } catch {
                        curViewRow.Cells["SkiYearAge"].Value = "";
                    }
                    try {
                        curViewRow.Cells["MemberStatus"].Value = (String)curDataRow["MemberStatus"];
                    } catch {
                        curViewRow.Cells["MemberStatus"].Value = "";
                    }
                    try {
                        curViewRow.Cells["UpdateDate"].Value = ((DateTime)curDataRow["UpdateDate"]).ToString("MM/dd/yy HH:mm");
                    } catch {
                        curViewRow.Cells["UpdateDate"].Value = "";
                    }
                }
                myViewIdx = curRowIdx;
                dataGridView.CurrentCell = dataGridView.Rows[myViewIdx].Cells["MemberId"];
                int curRow = myViewIdx + 1;
                RowStatusLabel.Text = "Row " + curRow.ToString() + " of " + dataGridView.Rows.Count.ToString();
            }
            winStatusMsg.Text = "Members retrieved";
            Cursor.Current = Cursors.Default;
        }

        private void navRefresh_Click( object sender, EventArgs e ) {
            myMemberListDataTable = getMemberList();
            loadDataGridView();
        }

        private void navExport_Click( object sender, EventArgs e ) {
            String[] curSelectCommand = new String[1];
            String[] curTableName = { "MemberList" };
            ExportData myExportData = new ExportData();

            curSelectCommand[0] = "Select * from MemberList ";
            if ( myFilterCommand == null ) {
                curSelectCommand[0] = curSelectCommand[0];
            } else {
                if ( myFilterCommand.Length > 0 ) {
                    curSelectCommand[0] = curSelectCommand[0]
                        + " Where " + myFilterCommand;
                } else {
                    curSelectCommand[0] = curSelectCommand[0];
                }
            }
            myExportData.exportData( curTableName, curSelectCommand );
        }

        private void navSort_Click( object sender, EventArgs e ) {
            // Display the form as a modal dialog box.
            sortDialogForm.SortCommand = mySortCommand;
            sortDialogForm.ShowDialog( this );

            // Determine if the OK button was clicked on the dialog box.
            if ( sortDialogForm.DialogResult == DialogResult.OK ) {
                mySortCommand = sortDialogForm.SortCommand;
                winStatusMsg.Text = "Sorted by " + mySortCommand;
                loadDataGridView();
            }
        }

        private void navFilter_Click( object sender, EventArgs e ) {
            // Display the form as a modal dialog box.
            filterDialogForm.ShowDialog( this );

            // Determine if the OK button was clicked on the dialog box.
            if ( filterDialogForm.DialogResult == DialogResult.OK ) {
                myFilterCommand = filterDialogForm.FilterCommand;
                winStatusMsg.Text = "Filtered by " + myFilterCommand;
                loadDataGridView();
            }
        }

        private void navInsert_Click( object sender, EventArgs e ) {
            // Open dialog for selecting skiers
            myEditMemberDialog.editMember( null );
            myEditMemberDialog.ShowDialog( this );

            // Refresh data from database
            if ( myEditMemberDialog.DialogResult == DialogResult.OK ) {
                navRefresh_Click( null, null );
            }
        }

        private void navEdit_Click( object sender, EventArgs e ) {
            DataGridView curView = dataGridView;

            //Send current member row
            if ( !( isObjectEmpty( curView.Rows[myViewIdx].Cells["MemberId"].Value ) ) ) {
                // Display the form as a modal dialog box.
                String curMemberId = (String)curView.Rows[myViewIdx].Cells["MemberId"].Value;
                myEditMemberDialog.editMember( curMemberId );
                myEditMemberDialog.ShowDialog( this );

                // Determine if the OK button was clicked on the dialog box.
                if ( myEditMemberDialog.DialogResult == DialogResult.OK ) {
                    navRefresh_Click( null, null );
                }
            }
        }

        private void dataGridView_CellContentDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            DataGridView curView = ( DataGridView )sender;

            if ( e.RowIndex >= 0 ) {
                myViewIdx = e.RowIndex;

                //Send current member row
                if ( !( isObjectEmpty( curView.Rows[myViewIdx].Cells["MemberId"].Value ) ) ) {
                    // Display the form as a modal dialog box.
                    String curMemberId = (String)curView.Rows[myViewIdx].Cells["MemberId"].Value;
                    myEditMemberDialog.editMember( curMemberId );
                    myEditMemberDialog.ShowDialog( this );

                    // Determine if the OK button was clicked on the dialog box.
                    if ( myEditMemberDialog.DialogResult == DialogResult.OK ) {
                        navRefresh_Click( null, null );
                    }
                }
            }
        }

        private void dataGridView_RowEnter( object sender, DataGridViewCellEventArgs e ) {
            myViewIdx = e.RowIndex;
            int curRow = myViewIdx + 1;
            RowStatusLabel.Text = "Row " + curRow.ToString() + " of " + dataGridView.Rows.Count.ToString();
        }

        private void navRemove_Click( object sender, EventArgs e ) {
            String curMemberId = "", curSkierName = "";
            bool curResults = true;

            DataGridViewRow curViewRow = dataGridView.Rows[myViewIdx];
            if ( curViewRow != null ) {
                try {
                    curMemberId = (String)curViewRow.Cells["MemberId"].Value;
                    curSkierName = (String)curViewRow.Cells["FirstName"].Value + " " + (String)curViewRow.Cells["LastName"].Value;

                    try {
                        myDbConn.Open();
                        mySqlStmt = myDbConn.CreateCommand();
                        mySqlStmt.CommandText = "Delete MemberList Where MemberId = '" + curMemberId + "'";
                        int rowsProc = mySqlStmt.ExecuteNonQuery();
                        winStatusMsg.Text = "Skier " + curSkierName + " entry removed";
                    } catch ( Exception excp ) {
                        curResults = false;
                        MessageBox.Show( "Error attempting to remove " + curSkierName + "\n" + excp.Message );
                    } finally {
                        myDbConn.Close();
                    }

                    if ( curResults ) {
                        loadDataGridView();
                    }

                } catch ( Exception excp ) {
                    curResults = false;
                    MessageBox.Show( "Error attempting to remove " + curSkierName + "\n" + excp.Message );
                }
            }
        }

        private void navRemoveAll_Click(object sender, EventArgs e) {
            String dialogMsg = "All members will be removed!"
                + "\n This will not affect any tournament registrations or scores."
                + "\n Do you want to continue?";
            DialogResult msgResp =
                MessageBox.Show( dialogMsg, "Truncate Warning",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1 );
            if (msgResp == DialogResult.Yes) {
                try {
                    //Prepare database interaction combonents for processing
                    //Open database connection
                    SqlCeCommand sqlStmt = null;
                    SqlCeConnection myDbConn = new global::System.Data.SqlServerCe.SqlCeConnection();
                    myDbConn.ConnectionString = Properties.Settings.Default.waterskiConnectionStringApp;
                    myDbConn.Open();
                    sqlStmt = myDbConn.CreateCommand();
                    sqlStmt.CommandText = "Delete MemberList ";
                    int rowsProc = sqlStmt.ExecuteNonQuery();
                    MessageBox.Show( rowsProc + " members removed" );
                    dataGridView.Rows.Clear();
                } catch (Exception excp) {
                    MessageBox.Show( "Error attempting to save changes \n" + excp.Message );
                }
            } else if (msgResp == DialogResult.No) {
            } else {
            }

        }

        private DataTable getMemberList() {
            StringBuilder curSqlStmt = new StringBuilder( "" );
            curSqlStmt.Append( "SELECT MemberId, LastName, FirstName, SkiYearAge, State, City, " );
            curSqlStmt.Append( "Country, DateOfBirth, Federation, Gender, MemberStatus, InsertDate, UpdateDate " );
            curSqlStmt.Append( "FROM MemberList " );
            curSqlStmt.Append( " Order by LastName, FirstName" );
            return getData( curSqlStmt.ToString() );
        }

        private DataTable getData( String inSelectStmt ) {
            return DataAccess.getDataTable( inSelectStmt );
        }

        private bool isObjectEmpty( object inObject ) {
            bool curReturnValue = false;
            if ( inObject == null ) {
                curReturnValue = true;
            } else if ( inObject == System.DBNull.Value ) {
                curReturnValue = true;
            } else if ( inObject.ToString().Length > 0 ) {
                curReturnValue = false;
            } else {
                curReturnValue = true;
            }
            return curReturnValue;
        }

    }
}