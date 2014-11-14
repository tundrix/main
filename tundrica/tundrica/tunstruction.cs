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

        tundrable[] static_atundrableobjects = { new progrix(), new clax(), new fundrix(), new voidrix(), new blox(), new commix(), new tuntributix(), new rux(), new vardeclarix() };

        interface tundrable
        {
            //void tundrableconstructor();
            string to_tundren_str();
            void to_tundren_sbstr(StringBuilder sb);
            //bool testsyntax();
            bool embody(string text); //i forgot what it is. see uix_embody()
            //tundrable[] getnclist();//nc = nested content
            //string[] getnestedxtypes();
            tundrable getmasterobject();
            void setmasterobject(tundrable masterobject);
            string static_getxtype();
            bool static_istundrixdatatype(); //static purpose
            string[] static_gettunstructioninterfaces();
            bool static_hasinterface(string tunstructioninterface);
            bool static_isopeningkey(string stringword);
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
            string[] static_getnestedxtypes();
            tundrable[] getnclist();//nc = nested content
            void addtundrable(tundrable t);
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
        //uix - functions for classes (implementation of methods)
        //uixlocal - functions for detail inner uix implementation
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
        static bool uixlocal_inastring(string str, string[] astr)//inastring = IN ArraySTRING
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

        string[] uixlocal_addstrtoastr(string[] astr, string str, bool checkunique)
        {
            if ((!uixlocal_inastring(str, astr)) || (!checkunique))
                //if new string or if add without checking doubling
            {
                string[] new_nestedcontent = new string[astr.Length + 1];
                for (int i = 0; i < astr.Length; i++)
                {
                    new_nestedcontent[i] = astr[i];
                }
                new_nestedcontent[astr.Length] = str;
                return new_nestedcontent;
            }
            else
            {
                return astr;
            }
        }

        string[] uixlocal_detectopeningtype(string str, string[] nestedxtypes)
        {
            string [] astr=new string[0];            
            for (int i = 0; i < static_atundrableobjects.Length; i++)
            {
                if (static_atundrableobjects[i].static_isopeningkey(str))
                {
                    string foundxtype = static_atundrableobjects[i].static_getxtype();
                    if ((uixlocal_inastring(foundxtype, nestedxtypes)) || (nestedxtypes.Length == 0))
                    {
                        astr = uixlocal_addstrtoastr(astr, foundxtype, true);
                    }
                }
            }
            return astr;
        }

         string uixlocal_readopeningtype(string tundrixtext, ref int caretposition, bool readnumberisword, string[] nestedxtypes)
        {
            int ccpos = caretposition;//Current Caret POSition
            int len = tundrixtext.Length;
            bool eos = (ccpos >= len);
            string res = "undefinedanswer";
            string curstr = "";

            bool isalreadyinword = false;
            bool eow = false;//end of word
            bool startedwithnumber = false;

            while (!eos)
            {
                char c = tundrixtext[caretposition];
                if (c != ';')
                {
                    curstr += c;
                    string[] answer = uixlocal_detectopeningtype(curstr, nestedxtypes);
                    if (answer.Length > 0)
                    {
                        if (answer.Length == 1)
                        {
                            return answer[0];
                        }
                        else
                        {
                            return "variety";
                        }
                    }
                }
                else
                {
                    return "eos";
                }


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

        static tundrable uix_mainreader(string text)
        {
             

            return null;
        }
        #endregion


        class progrix : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*program*/
        {
            string[] nestedxtypes = new string[] { "progrix", "vardeclarix", "blox" };
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
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
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
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
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
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
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
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
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
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            tundrable[] insetting.getnclist() { return nclist; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class commix : tundrable, canliveasstatementline
        // /*+ */
        {
            //tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "commix";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                //uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            //void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class tuntributix : tundrable, mustliveasstatementline, canliveasstatementline
        // /*+ */
        {
            //tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "tuntributix";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "mustliveasstatementline", "canliveasstatementline" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                //uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            //void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }   
        class rux : tundrable, valuable
        /*pd byte - platform dependent byte*/
        {
            //tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "rux";
            string[] openingkeys = new string[] { "" };
            string[] tunstructioninterfaces = new string[] { "tundrable", "valuable" };

            string tundrable.to_tundren_str() { return ""; }
            void tundrable.to_tundren_sbstr(StringBuilder sb)
            {
                sb.Append("<" + this_xtype + "'>" + rn);
                //uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            //void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class vardeclarix : tundrable, variabledeclaration, mustliveasstatementline, canliveasstatementline
        /*pd byte - platform dependent byte*/
        {
            //tundrable[] nclist = new tundrable[0];
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
                //uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            //void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string variabledeclaration.getxtype() { return xtype; }
            void variabledeclaration.setxtype(string _xtype) { xtype = _xtype; }
            string variabledeclaration.getvarname() { return varname; }
            void variabledeclaration.setvarname(string _varname) { varname = _varname; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class varblox : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*
         ...)
          bux:globaltruth;
          rux:globalyear;
         {...
         */
        {
            //tundrable[] nclist = new tundrable[0];
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
                //uix_nclist_to_tundren_str(sb, nclist);
                sb.Append("</" + this_xtype + ">" + rn);
            }
            string tundrable.static_getxtype() { return this_xtype; }
            bool tundrable.embody(string text) { return true; }
            //void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            bool tundrable.static_istundrixdatatype() { return false; }
            string variabledeclaration.getxtype() { return xtype; }
            void variabledeclaration.setxtype(string _xtype) { xtype = _xtype; }
            string variabledeclaration.getvarname() { return varname; }
            void variabledeclaration.setvarname(string _varname) { varname = _varname; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            bool tundrable.static_isopeningkey(string stringword) { return uixlocal_inastring(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }     
    }
}
