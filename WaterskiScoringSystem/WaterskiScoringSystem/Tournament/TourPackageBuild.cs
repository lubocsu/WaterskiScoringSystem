﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using WaterskiScoringSystem.Tools;
using WaterskiScoringSystem.Common;

namespace WaterskiScoringSystem.Tournament {
    public partial class TourPackageBuild : Form {
        private String mySanctionNum = "";
        private String myTourClass = "";
        private String myTourRules = "";
        private DataRow myTourRow = null;
        private DataRow myClassRow;
        private DataRow myClassCRow;
        private DataRow myClassERow;
        private ListTourClass myTourClassList;
        private CalcNops myNopsCalc;

        public TourPackageBuild() {
            InitializeComponent();
        }

        private void TourPackageBuild_Load( object sender, EventArgs e ) {
            mySanctionNum = Properties.Settings.Default.AppSanctionNum.Trim();
            myTourRow = getTourData();
            myTourRules = (String)myTourRow["Rules"];

            myTourClassList = new ListTourClass();
            myTourClassList.ListTourClassLoad();
            

            Timer curTimerObj = new Timer();
            curTimerObj.Interval = 5;
            curTimerObj.Tick += new EventHandler( validateTourData );
            curTimerObj.Start();
        }

        private void validateTourData( object sender, EventArgs e ) {
            if ( sender != null ) {
                Timer curTimerObj = (Timer)sender;
                curTimerObj.Stop();
                curTimerObj.Tick -= new EventHandler( validateTourData );
            }

            Cursor.Current = Cursors.WaitCursor;
            CheckTourData();
            CheckForIncompleteSkiers();
            CheckForChiefOfficials();
            CheckBoatUse();

            TourPackageButton.BeginInvoke( (MethodInvoker)delegate() {
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
            } );

        }

        private void CheckForIncompleteSkiers() {
            CalcScoreSummary myCalcScoreSummary = new CalcScoreSummary();
            DataTable curDataTable = myCalcScoreSummary.getIncompleteSkiers( mySanctionNum );

            TourPackageButton.BeginInvoke( (MethodInvoker)delegate() {
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
            } );

            if ( curDataTable.Rows.Count > 0 ) {
                StringBuilder curMsg = new StringBuilder( "" );
                curMsg.Append( "There are " + curDataTable.Rows.Count + " skiers that have incomplete scores or are marked as not ready to ski"
                    + "\nNote that skiers marked as not ready to ski will not be included in the scorebook or the skier performance file" );
                curMsg.Append( "\n\nSkierName AgeGroup Event Round Status" );
                foreach ( DataRow curRow in curDataTable.Rows ) {
                    curMsg.Append( "\n" + curRow["SkierName"]);
                    curMsg.Append( " " + curRow["AgeGroup"]);
                    curMsg.Append( " " + curRow["Event"] );
                    curMsg.Append( " " + curRow["Round"] );
                    curMsg.Append( " " + curRow["Status"] );
                }
                MessageBox.Show( curMsg.ToString() );
            }
        }

        private void CheckForChiefOfficials() {
            if ( myTourRow != null ) {
                //myTourClass = ( (String)myTourRow["EventScoreClass"] ).ToString().ToUpper().Trim();
                myTourClass = ( (String)myTourRow["Class"] ).ToString().ToUpper().Trim();
                myClassCRow = myTourClassList.TourClassDataTable.Select( "ListCode = 'C'" )[0];
                myClassERow = myTourClassList.TourClassDataTable.Select("ListCode = 'E'")[0];
                myClassRow = myTourClassList.TourClassDataTable.Select("ListCode = '" + myTourClass + "'")[0];

                DataTable curDataTable;
                String curValue = "", curMemberId = "";
                StringBuilder curMsg = new StringBuilder( "" );
                StringBuilder curSqlStmt = new StringBuilder( "" );
                curSqlStmt = new StringBuilder( "SELECT MemberId, JudgeChief FROM OfficialWork " );
                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "  And JudgeChief = 'Y'" );
                curDataTable = getData( curSqlStmt.ToString() );
                if (curDataTable.Rows.Count <= 0) {
                    curMsg.Append( "\n Chief judge is not assigned." );
                } else {
                    curMemberId = (String)curDataTable.Rows[0]["MemberId"];
                }
                curSqlStmt = new StringBuilder("SELECT ChiefJudgeMemberId FROM Tournament ");
                curSqlStmt.Append("WHERE SanctionId = '" + mySanctionNum + "' ");
                curDataTable = getData(curSqlStmt.ToString());
                if (curDataTable.Rows.Count > 0) {
                    try {
                        if (curDataTable.Rows[0]["ChiefJudgeMemberId"] == System.DBNull.Value) {
                            curValue = "";
                        } else {
                            curValue = (String)curDataTable.Rows[0]["ChiefJudgeMemberId"];
                        }
                        if (curValue.Length > 1) {
                        } else {
                            if (curMemberId.Length > 1) {
                                curSqlStmt = new StringBuilder( "Update Tournament Set ChiefJudgeMemberId = '" + curMemberId + "' " );
                                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                                int rowsProc = DataAccess.ExecuteCommand( curSqlStmt.ToString() );
                            } else {
                                curMsg.Append( "\n Chief judge is not available in Official Contacts." );
                            }
                        }
                    } catch {
                        curMsg.Append("\n Chief judge is not available in Official Contacts.");
                    }
                }

                curMemberId = "";
                curSqlStmt = new StringBuilder( "SELECT MemberId, DriverChief FROM OfficialWork " );
                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "  And DriverChief = 'Y'" );
                curDataTable = getData( curSqlStmt.ToString() );
                if ( curDataTable.Rows.Count <= 0 ) {
                    curMsg.Append( "\n Chief driver is not assigned." );
                } else {
                    curMemberId = (String)curDataTable.Rows[0]["MemberId"];
                }
                curSqlStmt = new StringBuilder("SELECT ChiefDriverMemberId FROM Tournament ");
                curSqlStmt.Append("WHERE SanctionId = '" + mySanctionNum + "' ");
                curDataTable = getData(curSqlStmt.ToString());
                if (curDataTable.Rows.Count > 0) {
                    try {
                        if (curDataTable.Rows[0]["ChiefDriverMemberId"] == System.DBNull.Value) {
                            curValue = "";
                        } else {
                            curValue = (String)curDataTable.Rows[0]["ChiefDriverMemberId"];
                        }
                        if (curValue.Length > 1) {
                        } else {
                            if (curMemberId.Length > 1) {
                                curSqlStmt = new StringBuilder( "Update Tournament Set ChiefDriverMemberId = '" + curMemberId + "' " );
                                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                                int rowsProc = DataAccess.ExecuteCommand( curSqlStmt.ToString() );
                            } else {
                                curMsg.Append( "\n Chief driver is not available in Official Contacts." );
                            }
                        }
                    } catch {
                        curMsg.Append("\n Chief driver is not available in Official Contacts.");
                    }
                }

                curMemberId = "";
                curSqlStmt = new StringBuilder( "SELECT MemberId, ScoreChief FROM OfficialWork " );
                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "  And ScoreChief = 'Y'" );
                curDataTable = getData( curSqlStmt.ToString() );
                if ( curDataTable.Rows.Count <= 0 ) {
                    curMsg.Append( "\n Chief scorer is not assigned." );
                } else {
                    curMemberId = (String)curDataTable.Rows[0]["MemberId"];
                }
                curSqlStmt = new StringBuilder("SELECT ChiefScorerMemberId FROM Tournament ");
                curSqlStmt.Append("WHERE SanctionId = '" + mySanctionNum + "' ");
                curDataTable = getData(curSqlStmt.ToString());
                if (curDataTable.Rows.Count > 0) {
                    try {
                        if (curDataTable.Rows[0]["ChiefScorerMemberId"] == System.DBNull.Value) {
                            curValue = "";
                        } else {
                            curValue = (String)curDataTable.Rows[0]["ChiefScorerMemberId"];
                        }
                        if (curValue.Length > 1) {
                        } else {
                            if (curMemberId.Length > 1) {
                                curSqlStmt = new StringBuilder( "Update Tournament Set ChiefScorerMemberId = '" + curMemberId + "' " );
                                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                                int rowsProc = DataAccess.ExecuteCommand( curSqlStmt.ToString() );
                            } else {
                                curMsg.Append( "\n Chief scorer is not available in Official Contacts." );
                            }
                        }
                    } catch {
                        curMsg.Append("\n Chief scorer is not available in Official Contacts.");
                    }
                }

                try {
                    curSqlStmt = new StringBuilder( "SELECT ContactEmail, ContactMemberId, ContactPhone FROM Tournament " );
                    curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                    curDataTable = getData( curSqlStmt.ToString() );
                    if ( curDataTable.Rows.Count > 0 ) {
                        try {
                            curValue = ((String)curDataTable.Rows[0]["ContactMemberId"]).Trim();
                            if (curValue.Length > 0) {
                            } else {
                                curMsg.Append("\n Primary contact has not been provided in the officials contact window.");
                            }
                            curValue = (String)curDataTable.Rows[0]["ContactEmail"];
                            if (curValue.Length > 0) {
                                int curDelimPos = curValue.IndexOf( '@' );
                                if ( curDelimPos > 0 ) {
                                    int curDelimPos2 = curValue.IndexOf( '.', curDelimPos );
                                    if ( curDelimPos2 > 0 ) {
                                    } else {
                                        curMsg.Append( "\n Primary contact email has not been provided in the officials contact window and is required." );
                                    }
                                } else {
                                    curMsg.Append( "\n Primary contact email has not been provided in the officials contact window and is required." );
                                }
                            } else {
                                curMsg.Append( "\n Primary contact email has not been provided in the officials contact window and is required." );
                            }
                        } catch {
                            curMsg.Append( "\n Primary contact has not been provided in the officials contact window and is required." );
                        }
                    } else {
                        curMsg.Append( "\n Primary contact email has not been provided in the officials contact window and is required." );
                    }
                } catch {
                    curMsg.Append( "\nPrimary contact email has not been provided in the officials contact window and is required." );
                }

                curMemberId = "";
                curSqlStmt = new StringBuilder( "SELECT MemberId, SafetyChief FROM OfficialWork " );
                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "  And SafetyChief = 'Y'" );
                curDataTable = getData( curSqlStmt.ToString() );
                if ( curDataTable.Rows.Count <= 0 ) {
                    curMsg.Append( "\n Chief safety is not assigned." );
                } else {
                    curMemberId = (String)curDataTable.Rows[0]["MemberId"];
                }
                curSqlStmt = new StringBuilder("SELECT SafetyDirMemberId FROM Tournament ");
                curSqlStmt.Append("WHERE SanctionId = '" + mySanctionNum + "' ");
                curDataTable = getData(curSqlStmt.ToString());
                if (curDataTable.Rows.Count > 0) {
                    try {
                        if (curDataTable.Rows[0]["SafetyDirMemberId"] == System.DBNull.Value) {
                            curValue = "";
                        } else {
                            curValue = (String)curDataTable.Rows[0]["SafetyDirMemberId"];
                        }
                        if (curValue.Length > 1) {
                        } else {
                            if (curMemberId.Length > 1) {
                                curSqlStmt = new StringBuilder( "Update Tournament Set SafetyDirMemberId = '" + curMemberId + "' " );
                                curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                                int rowsProc = DataAccess.ExecuteCommand( curSqlStmt.ToString() );
                            } else {
                                curMsg.Append( "\n Chief safety is not available in Official Contacts." );
                            }
                        }
                    } catch {
                        curMsg.Append("\n Chief safety is not available in Official Contacts.");
                    }

                }

                if ( (Decimal)myClassRow["ListCodeNum"] > (Decimal)myClassCRow["ListCodeNum"] ) {
                    //curEventClass = "R";
                    curSqlStmt = new StringBuilder( "SELECT MemberId, TechChief FROM OfficialWork " );
                    curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
                    curSqlStmt.Append( "  And TechChief = 'Y'" );
                    curDataTable = getData( curSqlStmt.ToString() );
                    if ( curDataTable.Rows.Count <= 0 ) {
                        curMsg.Append( "\n Chief tech controller is not assigned." );
                    }
                } else if ( (Decimal)myClassRow["ListCodeNum"] < (Decimal)myClassCRow["ListCodeNum"] ) {
                    //curEventClass = "N";
                } else {
                    //curEventClass = "C";
                }

                if ( curMsg.Length > 0 ) {
                    MessageBox.Show( curMsg.ToString() );
                }
            }
        }

        private void CheckTourData() {
            String curDateString = DateTime.Now.ToString( "yyyyMMdd HH:MM" );
            String curDateOut = curDateString.Substring( 0, 8 );
            String curTimeOut = curDateString.Substring( 9, 5 );
            String curEventDateOut = (String)myTourRow["EventDates"];
            try {
                DateTime curEventDate = Convert.ToDateTime( curEventDateOut );
                curEventDateOut = curEventDate.ToString( "MM/dd/yyyy" );
            } catch {
                MessageBox.Show( "The event date of " + curEventDateOut + " is not a valid date and must corrected" );
                curEventDateOut = myTourRow["EventDates"].ToString();
            }

            String curState = "", curCity = "", curSiteName = "";
            try {
                String[] curEventLocation = ( (String)myTourRow["EventLocation"] ).Split( ',' );
                if (curEventLocation.Length == 3) {
                    curSiteName = curEventLocation[0];
                    curCity = curEventLocation[1];
                    curState = curEventLocation[2];
                } else {
                    MessageBox.Show( "An event location is required."
                        + "\nPlease enter this information on the tournament window in the following format:\n"
                        + "\nSite Name followed by a comma, then the city, followed by a comma, then the 2 character state abbreviation"
                        );
                }
            } catch {
                MessageBox.Show( "An event location is required."
                    + "\nPlease enter this information on the tournament window in the following format:\n"
                    + "\nSite Name followed by a comma, then the city, followed by a comma, then the 2 character state abbreviation"
                    );
            }
        }

        private void CheckBoatUse() {
            DataTable curDataTable;
            String curValue = "";
            StringBuilder curMsg = new StringBuilder( "" );
            StringBuilder curSqlStmt = new StringBuilder( "" );
            curSqlStmt = new StringBuilder( "SELECT * FROM TourBoatUse " );
            curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' " );
            curDataTable = getData( curSqlStmt.ToString() );
            if (curDataTable.Rows.Count > 0) {
                foreach (DataRow curRow in curDataTable.Rows) {
                    if (isObjectEmpty( curRow["HullId"] )) {
                        curMsg.Append( "\n Boat " + (String)curRow["BoatModel"] + " not selected from approved list, correct if necessary" );
                    }
                    try {
                        if (( (String)curRow["SlalomUsed"] ).Equals( "N" )
                            && ( (String)curRow["TrickUsed"] ).Equals( "N" )
                            && ( (String)curRow["JumpUsed"] ).Equals( "N" )
                            && ( (String)curRow["SlalomCredit"] ).Equals( "N" )
                            && ( (String)curRow["TrickCredit"] ).Equals( "N" )
                            && ( (String)curRow["JumpCredit"] ).Equals( "N" )
                            && ( isObjectEmpty( (String)curRow["Notes"] ) )
                            && ( isObjectEmpty( (String)curRow["PreEventNotes"] ) )
                            ) {
                            curMsg.Append( "\n Boat " + (String)curRow["BoatModel"] + " has no indication of use or credit, if this is not correct update the information in the Boat Use window" );
                        }
                    } catch {
                        curMsg.Append( "\n Boat " + (String)curRow["BoatModel"] + " has no indication of use or credit, if this is not correct update the information in the Boat Use window" );
                    }
                }
            } else {
                curMsg.Append( "\n No tow boat entries found go to the Boat Use window enter the information.");
            }

            if (curMsg.Length > 0) {
                MessageBox.Show( curMsg.ToString() );
            }
        }

        private void RunAllButton_Click(object sender, EventArgs e) {
            PerfDataFileButton_Click( null, null );
            exportBoatTimesButton_Click( null, null );
            ScoreBookButton_Click( null, null );
            WebOutputButton_Click( null, null );
            ChiefJudgeReportButton_Click( null, null );
            OfficialCreditFileButton_Click( null, null );
            SafetyDirReportButton_Click( null, null );
            BoatUseReportButton_Click( null, null );
            TourPackageButton_Click( null, null );
        }

        private void PerfDataFileButton_Click( object sender, EventArgs e ) {
            //CheckForIncompleteSkiers();
            
            String mySanctionNum = Properties.Settings.Default.AppSanctionNum.Trim();
            ExportPerfData myExportData = new ExportPerfData();
            myExportData.exportTourPerfData( mySanctionNum );
        }

        private void ScoreBookButton_Click( object sender, EventArgs e ) {
            //CheckForIncompleteSkiers();

            if (myTourRules.ToLower().Equals("iwwfx") ) {
            } else if ( myTourRules.ToLower().Equals("ncwsa")) {
                ExportScoreBook curExportScoreBook = new ExportScoreBook();
                curExportScoreBook.exportScoreBookData();
            } else {
                ExportScoreBook curExportScoreBook = new ExportScoreBook();
                curExportScoreBook.exportScoreBookData();

                if (CheckForXClassScores()) {
                    curExportScoreBook.exportScoreBookDataXClass();
                }
            }
        }

        private bool CheckForXClassScores() {
            bool curReturnValue = false;

            StringBuilder curSqlStmt = new StringBuilder( "" );
            curSqlStmt.Append( "SELECT 'Slalom' AS Event, COUNT(*) AS SkierCount " );
            curSqlStmt.Append( "FROM SlalomScore " );
            curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' AND EventClass = 'X' " );
            curSqlStmt.Append( "UNION " );
            curSqlStmt.Append( "SELECT 'Trick' AS Event, COUNT(*) AS SkierCount " );
            curSqlStmt.Append( "FROM TrickScore " );
            curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' AND EventClass = 'X' " );
            curSqlStmt.Append( "UNION " );
            curSqlStmt.Append( "SELECT 'Jump' AS Event, COUNT(*) AS SkierCount " );
            curSqlStmt.Append( "FROM JumpScore " );
            curSqlStmt.Append( "WHERE SanctionId = '" + mySanctionNum + "' AND EventClass = 'X' " );
            DataTable curDataTable = getData( curSqlStmt.ToString() );

            int curSkierCount = 0;
            if (curDataTable.Rows.Count > 0) {
                foreach (DataRow curRow in curDataTable.Rows) {
                    curSkierCount = (int)curRow["SkierCount"];
                    if (curSkierCount > 0) {
                        curReturnValue = true;
                        break;
                    }
                }
            }

            return curReturnValue;
        }

        private void WebOutputButton_Click( object sender, EventArgs e ) {
            //CheckForIncompleteSkiers();

            if ( myTourRules.ToLower().Equals( "iwwf" ) ) {
                ExportScoreBookHtmlIwwf curObject = new ExportScoreBookHtmlIwwf();
                curObject.exportScoreBookData();
            } else if (myTourRules.ToLower().Equals( "ncwsa" )) {
                ExportScoreBookHtmlNcwsa curObject = new ExportScoreBookHtmlNcwsa();
                curObject.exportScoreBookData();
            } else {
                ExportScoreBookHtml curExportScoreBookHtml = new ExportScoreBookHtml();
                curExportScoreBookHtml.exportScoreBookData();
            }
        }

        private void ChiefJudgeReportButton_Click( object sender, EventArgs e ) {
            ChiefJudgeReport curForm = new ChiefJudgeReport();
            curForm.MdiParent = this.MdiParent;
            curForm.Show();
            curForm.RefreshButton_Click( null, null );
            curForm.ExportButton_Click( null, null );
            curForm.ExportReportPrintFile();
            //curForm.PrintButton_Click( null, null );
            curForm.Close();
        }

        private void OfficialCreditFileButton_Click( object sender, EventArgs e ) {
            CheckForChiefOfficials();
            ExportOfficialWorkFile myExportData = new ExportOfficialWorkFile();
            myExportData.ExportData();
        }

        private void SafetyDirReportButton_Click( object sender, EventArgs e ) {
            SafetyCheckList curForm = new SafetyCheckList();
            curForm.MdiParent = this.MdiParent;
            curForm.Show();
            curForm.RefreshButton_Click( null, null );
            curForm.ExportButton_Click( null, null );
            curForm.ExportReportPrintFile();
            //curForm.PrintButton_Click( null, null );
            curForm.Close();
        }

        private void BoatUseReportButton_Click( object sender, EventArgs e ) {
            ExportBoatUse curExport = new ExportBoatUse();
            curExport.ExportData();

            BoatUseReport curForm = new BoatUseReport();
            curForm.MdiParent = this.MdiParent;
            curForm.Show();
            curForm.RefreshButton_Click( null, null );
            curForm.ExportReportPrintFile();
            //curForm.PrintButton_Click( null, null );
            curForm.Close();
        }

        private void TourPackageButton_Click( object sender, EventArgs e ) {
            try {
                String curTourFolder = Properties.Settings.Default.ExportDirectory;
                if ( myTourRow != null ) {
                    using (FolderBrowserDialog curFolderDialog = new FolderBrowserDialog()) {
                        curFolderDialog.ShowNewFolderButton = true;
                        curFolderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                        curFolderDialog.SelectedPath = @curTourFolder;
                        if (FolderBrowserLauncher.ShowFolderBrowser( curFolderDialog, Form.ActiveForm ) == DialogResult.OK) {
                            curTourFolder = curFolderDialog.SelectedPath;
                        }
                    }
                    writeTourIdentDataFile( myTourRow, curTourFolder );

                    ExportTourSummary myExportTourSummary = new ExportTourSummary();
                    myExportTourSummary.ExportData();

                    ExportData myExportData = new ExportData();
                    String curTourDataFileName = curTourFolder;
                    if (curTourFolder.Substring( curTourFolder.Length - 1 ).Equals( "\\" )) {
                        curTourDataFileName += mySanctionNum + "TS.txt";
                    } else {
                        curTourDataFileName += "\\" + mySanctionNum + "TS.txt";
                    }
                    myExportData.exportTourData( mySanctionNum, curTourDataFileName );

                    Cursor.Current = Cursors.WaitCursor;
                    ArrayList curFileFilterList = getEndOfTourReportList( mySanctionNum, myTourClass );
                    ZipUtil.ZipFiles( curTourFolder, mySanctionNum + myTourClass + ".zip", curFileFilterList );
                    TourPackageButton.BeginInvoke( (MethodInvoker)delegate() {
                        Application.DoEvents();
                        Cursor.Current = Cursors.Default;
                    } );
                }
            } catch ( Exception ex ) {
                MessageBox.Show( "Exception selecting and compressing selected files from specified folder " + "\n\nError: " + ex.Message );
            }
        }

        private void writeTourIdentDataFile( DataRow inTourRow, String inOutputFolder ) {
            StringBuilder outLine = new StringBuilder( "" );
            String mySanctionNum = (String)inTourRow["SanctionId"];
            String curTourClass = (String)inTourRow["Class"];
            String curTourName = (String)inTourRow["Name"];
            String curTourFed = (String)inTourRow["Federation"];
            String curEventDate = "";
            try {
                DateTime curTourDate = Convert.ToDateTime( (String)inTourRow["EventDates"] );
                curEventDate = curTourDate.ToString( "MM-dd-yyyy" );
            } catch ( Exception ex ) {
                curEventDate = (String)inTourRow["EventDates"];
                MessageBox.Show( "The event date of " + (String)inTourRow["EventDates"] + " is not a valid date and must corrected" );
            }
            String curDeployVer = "";
            try {
                curDeployVer = Properties.Settings.Default.BuildVersion;
                curDeployVer = curDeployVer.Replace( ",", "" );
            } catch {
                curDeployVer = "Version not available ";
            }
            
            String curFileName = inOutputFolder + "/WWParm.TNY";
            StreamWriter outBuffer = File.CreateText( curFileName );

            outLine = new StringBuilder( Properties.Settings.Default.ExportDirectory + "," + Properties.Settings.Default.AppTitle + " " + curDeployVer );
            outBuffer.WriteLine( outLine.ToString() );

            outLine = new StringBuilder( curTourFed + "," + mySanctionNum + curTourClass + "," + curEventDate );
            outBuffer.WriteLine( outLine.ToString() );

            outLine = new StringBuilder( curTourName );
            outBuffer.WriteLine( outLine.ToString() );

            outBuffer.Close();
        }
        
        private void exportBoatTimesButton_Click( object sender, EventArgs e ) {
            String mySanctionNum = Properties.Settings.Default.AppSanctionNum.Trim();

            ExportBoatTimeReport myExportDataReport = new ExportBoatTimeReport();
            myExportDataReport.exportBoatTimes( mySanctionNum );

            ExportBoatTimesJump myExportDataJump = new ExportBoatTimesJump();
            myExportDataJump.exportBoatTimes( mySanctionNum );

            ExportBoatTimesSlalom myExportDataSlalom = new ExportBoatTimesSlalom();
            myExportDataSlalom.exportBoatTimes( mySanctionNum );
        }

        private void UpdateNops_Click( object sender, EventArgs e ) {
            //Update NOPS values due to unavailable 2015 NOPS tables
            //Prior to version 1.0.1.82
            String curMsg = "This process will re-calculate all NOPS values for the current tournament "
                + "based on the 2015 NOPS factors that were not available at the start of the 2015 ski season."
                + "\n\nThis should include any 2015 tournaments scored before verion 2.1.1.0 was available and used."
                + "\n\nClick OK to begin the update process";
            DialogResult msgResp = MessageBox.Show( curMsg, "Updater Notice",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 );
            if (msgResp == DialogResult.OK) {
                if (execUpdateNops()) {
                    curMsg = "Click OK to rebuild the Scorebook, Web Scorebook, Skier Performance file, and update the tournament package ZIP file";
                    msgResp = MessageBox.Show( curMsg, "Update Notice",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 );
                    if (msgResp == DialogResult.OK) {
                        ScoreBookButton_Click( null, null );
                        WebOutputButton_Click( null, null );
                        PerfDataFileButton_Click( null, null );
                        TourPackageButton_Click( null, null );
                    }
                } else {
                    MessageBox.Show( "\nReport updating has not been performed because issues have been detected with the NOPS update"
                        + "\nPlease correct the errors shown and then retry" );
                }
            }
        }

        private bool execUpdateNops() {
            //Update NOPS values due to unavailable 2014 NOPS tables
            //Prior to version 1.0.1.82
            bool curReturnValue = true;

            SqlCeCommand sqlStmt = null;
            SqlCeConnection myDbConn = null;
            DataTable myDataTable = new DataTable();
            StringBuilder curSqlStmt = new StringBuilder();
            List<Common.ScoreEntry> curScoreList = new List<Common.ScoreEntry>();
            int rowsProc, rowUpdateCount = 0;

            try {
                myDbConn = new global::System.Data.SqlServerCe.SqlCeConnection();
                myDbConn.ConnectionString = Properties.Settings.Default.waterskiConnectionStringApp;
                myDbConn.Open();
                sqlStmt = myDbConn.CreateCommand();

                myNopsCalc = CalcNops.Instance;
                myNopsCalc.LoadDataForTour();
                curScoreList.Add( new Common.ScoreEntry( "Trick", 0, "", 0 ) );

                curSqlStmt = new StringBuilder();
                curSqlStmt.Append( "Select PK, SanctionId, MemberId, AgeGroup, Score, Round " );
                curSqlStmt.Append( "From TrickScore " );
                curSqlStmt.Append( "Where SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "Order by AgeGroup, MemberId, Round " );
                myDataTable = getData( curSqlStmt.ToString() );

                rowUpdateCount = 0;
                foreach (DataRow curRow in myDataTable.Rows) {
                    try {
                        curScoreList[0].Nops = 0;
                        curScoreList[0].Score = Convert.ToDecimal( (Int16)curRow["Score"] );
                        myNopsCalc.calcNops( (String)curRow["AgeGroup"], curScoreList );

                        sqlStmt.CommandText = "Update TrickScore "
                            + "SET NopsScore = " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " "
                            + "WHERE PK = " + (Int64)curRow["PK"]
                            + "  And NopsScore != " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " ";
                        rowsProc = sqlStmt.ExecuteNonQuery();
                        rowUpdateCount += rowsProc;
                        if (rowsProc == 0) {
                            //MessageBox.Show( "Record for " + (String)curRow["MemberId"] + " not updated \nCalculated value is " + Math.Round( curScoreList[0].Nops, 1 ).ToString() );
                        }
                    } catch (Exception ex) {
                        String ExcpMsg = ex.Message;
                        if (sqlStmt != null) {
                            ExcpMsg += "\n" + sqlStmt.CommandText;
                        }
                        MessageBox.Show( "Error updating trick NOPS " + "\n\nError: " + ExcpMsg );
                        curReturnValue = false;
                    }
                }
                MessageBox.Show( myDataTable.Rows.Count.ToString() + " Trick scores read"
                    + "\nTrick NOPS scores updated = " + rowUpdateCount.ToString()
                    + "\nNote: Records with no change in score were bypassed" );

                curScoreList[0].Event = "Jump";
                curSqlStmt = new StringBuilder();
                curSqlStmt.Append( "Select PK, SanctionId, MemberId, AgeGroup, ScoreFeet, Round " );
                curSqlStmt.Append( "From JumpScore " );
                curSqlStmt.Append( "Where SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "Order by AgeGroup, MemberId, Round " );
                myDataTable = getData( curSqlStmt.ToString() );

                rowUpdateCount = 0;
                foreach (DataRow curRow in myDataTable.Rows) {
                    try {
                        curScoreList[0].Nops = 0;
                        curScoreList[0].Score = (Decimal)curRow["ScoreFeet"];
                        myNopsCalc.calcNops( (String)curRow["AgeGroup"], curScoreList );

                        sqlStmt.CommandText = "Update JumpScore "
                            + "SET NopsScore = " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " "
                            + "WHERE PK = " + (Int64)curRow["PK"]
                            + "  And NopsScore != " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " ";
                        rowsProc = sqlStmt.ExecuteNonQuery();
                        rowUpdateCount += rowsProc;
                        if (rowsProc == 0) {
                            //MessageBox.Show( "Record for " + (String)curRow["MemberId"] + " not updated \nCalculated value is " + Math.Round( curScoreList[0].Nops, 1 ).ToString() );
                        }
                    } catch (Exception ex) {
                        String ExcpMsg = ex.Message;
                        if (sqlStmt != null) {
                            ExcpMsg += "\n" + sqlStmt.CommandText;
                        }
                        MessageBox.Show( "Error updating jump NOPS \n\nError: " + ExcpMsg );
                        curReturnValue = false;
                    }
                }
                MessageBox.Show( myDataTable.Rows.Count.ToString() + " Jump scores read"
                    + "\nJump NOPS scores updated = " + rowUpdateCount.ToString()
                    + "\nNote: Records with no change in score were bypassed" );

                curScoreList[0].Event = "Slalom";
                curSqlStmt = new StringBuilder();
                curSqlStmt.Append( "Select PK, SanctionId, MemberId, AgeGroup, Score, Round " );
                curSqlStmt.Append( "From SlalomScore " );
                curSqlStmt.Append( "Where SanctionId = '" + mySanctionNum + "' " );
                curSqlStmt.Append( "Order by AgeGroup, MemberId, Round " );
                myDataTable = getData( curSqlStmt.ToString() );

                rowUpdateCount = 0;
                foreach (DataRow curRow in myDataTable.Rows) {
                    try {
                        curScoreList[0].Nops = 0;
                        curScoreList[0].Score = (Decimal)curRow["Score"];
                        myNopsCalc.calcNops( (String)curRow["AgeGroup"], curScoreList );

                        sqlStmt.CommandText = "Update SlalomScore "
                            + "SET NopsScore = " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " "
                            + "WHERE PK = " + (Int64)curRow["PK"]
                            + "  And NopsScore != " + Math.Round( curScoreList[0].Nops, 1 ).ToString() + " ";
                        rowsProc = sqlStmt.ExecuteNonQuery();
                        rowUpdateCount += rowsProc;
                        if (rowsProc == 0) {
                            //MessageBox.Show( "Record for " + (String)curRow["MemberId"] + " not updated \nCalculated value is " + Math.Round( curScoreList[0].Nops, 1 ).ToString() );
                        }
                    } catch (Exception ex) {
                        String ExcpMsg = ex.Message;
                        if (sqlStmt != null) {
                            ExcpMsg += "\n" + sqlStmt.CommandText;
                        }
                        MessageBox.Show( "Error updating Slalom NOPS \n\nError: " + ExcpMsg );
                        curReturnValue = false;
                    }
                }
                MessageBox.Show( myDataTable.Rows.Count.ToString() + " Slalom scores read"
                    + "\nSlalom NOPS scores updated = " + rowUpdateCount.ToString()
                    + "\nNote: Records with no change in score were bypassed" );

            } catch (Exception excp) {
                String curMsg = ":Error attempting to update 2015 Nops values \n" + excp.Message;
                MessageBox.Show( curMsg );
                curReturnValue = false;
            } finally {
                myDbConn.Close();
            }
            return curReturnValue;
        }

        public ArrayList getEndOfTourReportList(String inSanctionNum, String inTourClass) {
            StringBuilder curSqlStmt = new StringBuilder( "" );
            curSqlStmt.Append( "SELECT ListCode, SortSeq, CodeValue, CodeDesc" );
            curSqlStmt.Append( " FROM CodeValueList" );
            curSqlStmt.Append( " WHERE ListName = 'EndOfTourReports'" );
            curSqlStmt.Append( " ORDER BY SortSeq" );
            DataTable curDataTable = getData( curSqlStmt.ToString() );

            String curFileName, curFileMask;
            ArrayList curFileList = new ArrayList();
            foreach ( DataRow curRow in curDataTable.Rows ) {
                curFileMask = (String)curRow["CodeValue"];
                if ( curFileMask.StartsWith( "######" ) ) {
                    curFileName = inSanctionNum;
                    if ( curFileMask.Substring( 6, 1 ).Equals( "*" ) ) {
                        curFileName += inTourClass + curFileMask.Substring( 7 );
                    } else {
                        curFileName += curFileMask.Substring( 6 );
                    }
                } else {
                    curFileName = curFileMask;
                }
                curFileList.Add( curFileName.ToLower() );
            }

            return curFileList;
        }

        private DataRow getTourData() {
            DataRow curRow = null;
            try {
                //Retrieve selected tournament attributes
                StringBuilder curSqlStmt = new StringBuilder( "" );
                curSqlStmt.Append( "SELECT SanctionId, ContactMemberId, Name, Class, COALESCE(L.CodeValue, 'C') as EventScoreClass, T.Federation" );
                curSqlStmt.Append( ", SlalomRounds, TrickRounds, JumpRounds, Rules, EventDates, EventLocation" );
                curSqlStmt.Append( ", ContactPhone, ContactEmail, M.LastName + ', ' + M.FirstName AS ContactName " );
                curSqlStmt.Append( "FROM Tournament T " );
                curSqlStmt.Append( "LEFT OUTER JOIN MemberList M ON ContactMemberId = MemberId " );
                curSqlStmt.Append( "LEFT OUTER JOIN CodeValueList L ON ListName = 'ClassToEvent' AND ListCode = T.Class " );
                curSqlStmt.Append( "WHERE T.SanctionId = '" + mySanctionNum + "' " );
                DataTable curDataTable = getData( curSqlStmt.ToString() );
                if ( curDataTable.Rows.Count > 0 ) {
                    curRow = curDataTable.Rows[0];
                    return curRow;
                } else {
                    return null;
                }
            } catch ( Exception ex ) {
                MessageBox.Show( "Exception retrieving tournament data " + "\n\nError: " + ex.Message );
                return null;
            }
        }

        private DataTable getData( String inSelectStmt ) {
            return DataAccess.getDataTable( inSelectStmt );
        }

        private bool isObjectEmpty(object inObject) {
            bool curReturnValue = false;
            if (inObject == null) {
                curReturnValue = true;
            } else if (inObject == System.DBNull.Value) {
                curReturnValue = true;
            } else if (inObject.ToString().Length > 0) {
                curReturnValue = false;
            } else {
                curReturnValue = true;
            }
            return curReturnValue;
        }

    }
}