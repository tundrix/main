using System;
using System.Collections.Generic;
using System.Text;

namespace tundrica
{
    class tunstruction
    {
        string[] allxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
        /*struct resultvalue
        {
            string valuetype;
            byte[] abvalue;
            string svalue;
        }*/

        interface tundrable
        {
            string to_tundren_str();
            void to_tundren_sbstr(StringBuilder sb);
            //bool testsyntax();
            bool embody(string text);
            tundrable[] getnclist();//nc = nested content
            void addtundrable(tundrable t);
            //string[] getnestedxtypes();
            bool istundrixdatatype();
        }
        interface yourlangable
        {
            string to_yourlang_str();
        }

        interface valuable
        {/*
            resultvalue getvalue();
            void setvalue(resultvalue rv);
          */
        }

        interface insetting //has nested content
        {
            string[] getnestedxtypes();         
        }

        #region univesum implementation
        static string rn = "\r\n";
        static tundrable[] uix_addtundrable(tundrable[] at, tundrable t)
        {
            tundrable[] new_nestedcontent = new tundrable[at.Length + 1];
            for (int i = 0; i < at.Length; i++)
            {
                new_nestedcontent[i] = at[i];
            }
            new_nestedcontent[at.Length] = t;
            return new_nestedcontent;
        }
        static void uix_nclist_to_tundren_str(StringBuilder sb, tundrable[] at)
        {
            for (int i = 1; i < at.Length; i++)
            {
                at[i].to_tundren_sbstr(sb);
            }
        }
        static bool uixlocal_inastring(string str, string[] astr)
        {
            for (int i = 0; i < astr.Length; i++)
            {
                if (astr[i] == str)
                    return true;
            }
            return false;
        }
        static tundrable[] uix_embody(string[] nestedxtypes, string[] advisory, string tundrixtext, ref int caretposition)
        {
            tundrable[] nclist = new tundrable[0];
            //bool ignoreuntilblox = uixlocal_inastring("ignoreuntilblox", advisory);
            //bool ignoreuntilblox_stillactual = ignoreuntilblox;

            int nestedxtypescount = nestedxtypes.Length;
            bool[] maybextype = new bool[nestedxtypescount];

            int ccpos = caretposition;
            int len = tundrixtext.Length;
            bool eos = (ccpos >= len);

            while (!eos)
            {
                char c = tundrixtext[caretposition];
                for (int i = 0; i < nestedxtypescount; i++)
                {

                }

                ccpos++;
                eos = (ccpos >= len);
            }

            return nclist;
        }
        #endregion


        class progrix : tundrable, insetting
        /*program*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "progrix";
            string this_name = "";
            string tundrable.to_tundren_str()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<" + this_xtype + " name='" + this_name + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
                return sb.ToString();
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + " name='" + this_name + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true; 
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
            string[] insetting.getnestedxtypes()
            {
                return nestedxtypes;
            }
        }
        class clax : tundrable, insetting
        /*class*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "clax";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
            string[] insetting.getnestedxtypes()
            {
                return nestedxtypes;
            }
        }
        class fundrix : tundrable, valuable, insetting
        /*function*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "fundrix";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
            string[] insetting.getnestedxtypes()
            {
                return nestedxtypes;
            }
        }
        class voidrix : tundrable, insetting
        /*procedure*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "voidrix";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
            string[] insetting.getnestedxtypes()
            {
                return nestedxtypes;
            }
        }
        class blox : tundrable, insetting
        /*{...}*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "blox";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
            string[] insetting.getnestedxtypes()
            {
                return nestedxtypes;
            }
        }
        class commix : tundrable
        // /*+ */
        {
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "commix";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
        }
        class rux : tundrable, valuable
        /*pd byte - platform dependent byte*/
        {
            tundrable[] nclist = new tundrable[0];

            string this_xtype = "rux";
            string tundrable.to_tundren_str()
            {
                return "";
            }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text)
            {
                return true;
            }
            tundrable[] tundrable.getnclist()
            {
                return nclist;
            }
            void tundrable.addtundrable(tundrable t)
            {
                nclist = uix_addtundrable(nclist, t);
            }
            bool tundrable.istundrixdatatype()
            {
                return false;
            }
        }
    }
}
