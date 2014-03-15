﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MangaReader {

    /*
     * PictureManagerClass. The PictureManager class adds another layer of abstraction. It is responsible for keeping track of the current position in the image files list and loading the corresponding file into
     * the PictureBox of the corresponding form
     */
     internal class PictureManager {

        private FileManager FM; 
        private BasicReader thisform;  
        private int CurrentPosition;
        private int FormNumber;

        public PictureManager(FileManager FM, 
                              BasicReader thisform, 
                              int CurrentPosition, 
                              int FormNumber) { //Constructor: CurrentPosition is defaulted to the first position. 
            this.FM = FM;
            this.thisform = thisform;
            Initialize(CurrentPosition);
            this.FormNumber = FormNumber;
        }

        /* ------ Initialization Methods ---- */

        internal void Initialize(int pos_to_use) {
            CurrentPosition = pos_to_use;
            LoadPic(FM.getPicAtPos(ref CurrentPosition));
        }
  
        /* ------ File Traversal Methods ---- */

        internal void GotoNext() { 
            updatePic(FM.GetNextPos(ref CurrentPosition));
        }

        internal void GoBack() {
            updatePic(FM.GetPrevPos(ref CurrentPosition));
        }
       
        internal void updatePic(String Path) {
            LoadPic(Path);
            thisform.ChangeDirectoryTextBox(Path);
        }

        private void LoadPic(String PathName) {
            thisform.LoadPic(PathName);
        }

        /* ------ Accessor Methods ---------- */

        internal FileManager FileMana {
            get {
                return FM;
            }

            set {
                FM = value;
            }
        }

        internal int CurrentPos {
            get {
                return CurrentPosition;
            }
        }

        internal int FormNum {
            get {
                return FormNumber;
            }
        }

    }
}