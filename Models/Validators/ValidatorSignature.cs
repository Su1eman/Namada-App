using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Validators
{
    public class ValidatorSignature
    {
        private uint height;
        private bool? status;           //  Proposed = true, Signed = false, Missed = null

        [PrimaryKey, AutoIncrement]
        public uint Height
        {
            get { return height; }
            set
            {
                if (height == value) { return; }
                height = value;
            }
        }

        public bool? Status
        {
            get { return status; }
            set
            {
                if (status == value) { return; }
                status = value;
            }
        }
    }
}