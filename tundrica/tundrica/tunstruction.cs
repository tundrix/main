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
        string[] openingwords = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };        /*struct resultvalue
        {
            string valuetype;
            byte[] abvalue;
            string svalue;
        }*/

        interface tundrable
        {
            //void tundrableconstructor();
            string to_tundren_str();
            void to_tundren_sbstr(StringBuilder sb);
            //bool testsyntax();
            bool embody(string text);
            //tundrable[] getnclist();//nc = nested content
            void addtundrable(tundrable t);
            //string[] getnestedxtypes();
            bool istundrixdatatype();
            string[] gettunstructioninterfaces();
            bool hasinterface(string tunstructioninterface);
            bool isopeningkey(string stringword);
            tundrable getmasterobject();
            void setmasterobject(tundrable masterobject);
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
            tundrable[] getnclist();//nc = nested content
        }
        interface variabledeclaration
        {
            string getxtype();
            void setxtype(string _xtype);
            string getvarname();
            void setvarname(string _varname);
        }

        interface mustliveasstatementline { }
        interface canliveasstatementline { }

        #region universum implementation
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
        static string uixlocal_readstringword(string tundrixtext, ref int caretposition, bool readnumberisword)
        {
            int ccpos = caretposition;
            int len = tundrixtext.Length;
            bool eos = (ccpos >= len);
            string res = "";

            bool isalreadyinword = false;
            bool eow = false;
            bool startedwithnumber = false;

            while (!eos)
            {
                char c = tundrixtext[caretposition];

                if (!isalreadyinword)
                {
                    if ((('a' <= c) && (c <= 'z')) || (c == '_'))
                    {
                        isalreadyinword = true;
                    }
                    if (readnumberisword)
                    {
                        if (('0' <= c) && (c <= '9'))
                        {
                            isalreadyinword = true;
                            startedwithnumber = true;
                        }
                    }
                }
                if (isalreadyinword)
                {
                    if (!startedwithnumber)
                    {
                        if (!((('a' <= c) && (c <= 'z')) ||
                              (c == '_') ||
                              (('0' <= c) && (c <= '9'))))
                        {
                            eow = true;
                        }
                    }
                    else
                    {
                        if (!((('a' <= c) && (c <= 'z')) ||
                              (c == '_') ||
                              (('0' <= c) && (c <= '9'))))
                        {
                            eow = true;
                        }
                    }
                    if (readnumberisword)
                    {
                        if (!((('0' <= c) && (c <= '9')) ||
                            (c == '.')))
                        {
                            eow = true;
                        }
                    }
                }

                if (eow)
                {
                    return res;
                }
                else
                {
                    if (isalreadyinword && (eow))
                    {
                        res += c;
                    }
                }

                ccpos++;
                eos = (ccpos >= len);
            }
            return res;
        }

        static string uixlocal_readopeningstatement(string tundrixtext, ref int caretposition, bool readnumberisword)
        {
            int ccpos = caretposition;
            int len = tundrixtext.Length;
            bool eos = (ccpos >= len);
            string res = "";

            bool isalreadyinword = false;
            bool eow = false;
            bool startedwithnumber = false;

            while (!eos)
            {
                char c = tundrixtext[caretposition];


                ccpos++;
                eos = (ccpos >= len);
            }
            return res;
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


        class progrix : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*program*/
        {
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
            string this_xtype = "progrix";
            string[] openingkeys = new string[] { "progrix" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "insetting", "mustliveasstatementline", "canliveasstatementline" };
            tundrable[] nclist = new tundrable[0];
            tundrable master = null;

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
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] insetting.getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class clax : tundrable, insetting, mustliveasstatementline, canliveasstatementline
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
            tundrable master = null;

            string this_xtype = "clax";
            string[] openingkeys = new string[] { "clax" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "insetting", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] insetting.getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class fundrix : tundrable, valuable, insetting, mustliveasstatementline, canliveasstatementline
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
            tundrable master = null;

            string this_xtype = "fundrix";
            string[] openingkeys = new string[] { "fundrix" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "valuable", "insetting", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] insetting.getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class voidrix : tundrable, insetting, mustliveasstatementline, canliveasstatementline
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
            tundrable master = null;

            string this_xtype = "voidrix";
            string[] openingkeys = new string[] { "voidrix" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "insetting", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] insetting.getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class blox : tundrable, insetting, mustliveasstatementline, canliveasstatementline
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
            tundrable master = null;

            string this_xtype = "blox";
            string[] openingkeys = new string[] { "{" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "insetting", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] insetting.getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class commix : tundrable, canliveasstatementline
        // /*+ */
        {
            tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "commix";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class tuntributix : tundrable, mustliveasstatementline, canliveasstatementline
        // /*+ */
        {
            tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "tuntributix";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }   
        class rux : tundrable, valuable
        /*pd byte - platform dependent byte*/
        {
            tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "rux";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "valuable" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class vardeclarix : tundrable, variabledeclaration, mustliveasstatementline, canliveasstatementline
        /*pd byte - platform dependent byte*/
        {
            tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "vardeclarix";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "variabledeclaration", "mustliveasstatementline", "canliveasstatementline" };

            string xtype = "";
            string varname = "";
            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + " xtype='" + xtype + " varname='" + varname + "'>" + rn);
                uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            bool tundrable.embody(string text) { return true; }
            void tundrable.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.istundrixdatatype() { return false; }
            string variabledeclaration.getxtype() { return xtype; }
            void variabledeclaration.setxtype(string _xtype) { xtype = _xtype; }
            string variabledeclaration.getvarname() { return varname; }
            void variabledeclaration.setvarname(string _varname) { varname = _varname; }
            string[] tundrable.gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }        
    }
}
