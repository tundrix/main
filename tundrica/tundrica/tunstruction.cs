using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

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

        tundrable[] static_atundrableobjects = null;
        public tunstruction()
        {
            static_atundrableobjects = new tundrable[] { new progrix(this), new clax(this), new fundrix(this), new voidrix(this), new blox(this), new commix(this), new tuntributix(this), new rux(this), new vardeclarix(this) };
        }

        public interface tundrable
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
            int static_isopeningkey(string stringword);
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

        bool uixlocal_cinstring(char c, string str)//Char IN STRING
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (c == str[i])
                    return true;
            }
            return false;
        }

        bool uixlocal_dotequivalent(char c)
        {
            string equivalents = " .,()[]{}~!@#$%^&*/+-\r\n\t\"№;%:?\\|";
            for (int i = 0; i < equivalents.Length; i++)
            {
                if (c == equivalents[i])
                    return true;
            }
            return false;
        }
        bool uixlocal_commaequivalent(char c)
        {
            string equivalents = ".,()[]{}~!@#$%^&*/+-\r\n\t\"№;%:?\\|";
            for (int i = 0; i < equivalents.Length; i++)
            {
                if (c == equivalents[i])
                    return false;
            }
            return true;
        }

        int uix_isopeningkey(string str, string[] akeys)
            //int result show how many symblos were readed for opentype word
            //if (result > 0) => good answer
            //if (result == 0) => "false" answer
        {
            bool[] abreak = new bool[akeys.Length];
            int[] alenwodot = new int[akeys.Length];//Array LEN WithOut DOT
            for (int j = 0; j < akeys.Length; j++)
            {
                abreak[j] = false;
                alenwodot[j] = 0;
            }
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < akeys.Length; j++)
                {
                    if (akeys[j].Length > i)
                    {
                        if ((akeys[j][i] != '.') && (akeys[j][i] != ','))
                        {
                            if (akeys[j][i] != str[i])
                            {
                                abreak[j] = true;
                            }
                        }
                        if (akeys[j][i] == '.')
                        {
                            if (!uixlocal_dotequivalent(str[i]))
                            {
                                abreak[j] = true;
                            }
                        }
                        if (akeys[j][i] == ',')
                        {
                            if (!uixlocal_commaequivalent(str[i]))
                            {
                                abreak[j] = true;
                            }
                        }
                    }
                    if (!abreak[j])
                    {
                        if ((i + 1) < akeys[j].Length)
                        {
                            if (((akeys[j][i + 1] != '.') && (akeys[j][i + 1] != ',')) || ((akeys[j][i] != '.') && (akeys[j][i] != ',')))
                            {
                                alenwodot[j]++;
                            }
                        }
                    }
                    if (akeys[j].Length == (i + 1))
                    {
                        if (!abreak[j])
                        {
                            if ((akeys[j][i] != '.') && (akeys[j][i] != ','))
                            {
                                alenwodot[j]++;
                            }
                            return alenwodot[j];
                        }
                    }
                }
            }
            return 0;
        }
        /*
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
        */
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

        string[] uixlocal_detectopeningtype(string str, string[] nestedxtypes, out int readshift)
        {
            string[] astr = new string[0];
            int tmpreadshift = 0;
            for (int i = 0; i < static_atundrableobjects.Length; i++)
            {
                int openingwordlen = static_atundrableobjects[i].static_isopeningkey(str);
                if (tmpreadshift > 0)
                    if (openingwordlen > 0)
                        tmpreadshift = 0;
                //tmpreadshift = openingwordlen;
                if (openingwordlen > 0)
                {
                    string foundxtype = static_atundrableobjects[i].static_getxtype();
                    if ((uixlocal_inastring(foundxtype, nestedxtypes)) || (nestedxtypes.Length == 0))
                    {
                        if (astr.Length == 0)
                            tmpreadshift = openingwordlen;
                        astr = uixlocal_addstrtoastr(astr, foundxtype, true);
                    }
                }
            }
            readshift = tmpreadshift;
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

            bool curstrstarted=false;

            while (!eos)
            {
                char c = tundrixtext[ccpos];                
                //if (c != ';')
                if ((!uixlocal_cinstring(c, " ;\t\r\n")) || (curstrstarted))
                {
                    curstrstarted=true;
                    curstr += c;
                    int readshif = 0;
                    string[] answer = uixlocal_detectopeningtype(curstr, nestedxtypes, out readshif);
                    if (answer.Length > 0)
                    {
                        if (answer.Length == 1)
                        {
                            caretposition += readshif;
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
                    if (!curstrstarted)
                    {
                        caretposition++;
                        //}
                        //else
                        //{
                    }
                    else
                    {
                        return "eos";
                    }
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

        tundrable uixlocal_recursionread(string tundrixtext, ref int caretposition, bool readnumberisword, string[] nestedxtypes, TextBox tb17)
        {
            string openingtype = uixlocal_readopeningtype(tundrixtext, ref caretposition, false, nestedxtypes);
            MessageBox.Show("openingtype: \"" + openingtype+"\"");
            tb17.Text += "\r\n"+openingtype;
            string[] errors = { "undefinedanswer", "variety", "eos" };
            if (!uixlocal_inastring(openingtype, errors))
            {
                tundrable statictundrable = null;
                for (int i = 0; i < static_atundrableobjects.Length; i++)
                {
                    if (static_atundrableobjects[i].static_getxtype() == openingtype)
                    {
                        statictundrable = static_atundrableobjects[i];
                    }
                }
                if (statictundrable != null)
                {
                    if (statictundrable.static_getxtype() == "progrix")
                    {
                        string tundrixname = ((progrix)statictundrable).spec_readprogrixname(tundrixtext, ref caretposition);
                        MessageBox.Show("tundrix name: \"" + tundrixname + "\"");
                        tb17.Text += " " + tundrixname + ";";
                    }
                    if (statictundrable.static_getxtype() == "tuntributix")
                    {
                        string tuntributixtext = ((tuntributix)statictundrable).spec_tuntributix(tundrixtext, ref caretposition);
                        MessageBox.Show("tuntributix name: \"" + tuntributixtext + "\"");
                        tb17.Text += " " + tuntributixtext + ";";
                    }

                    if (statictundrable.static_hasinterface("insetting"))
                        uixlocal_recursionread(tundrixtext, ref caretposition, false, ((insetting)statictundrable).static_getnestedxtypes(), tb17);
                }
            }
            return null;
        }

        #endregion

        public tundrable uixpublic_mainreader(string tundrixtext, TextBox tb17)
        {
            int xx = 0;
            tb17.Text = "";
            tundrable tundrableobject = uixlocal_recursionread(tundrixtext, ref xx, false, new string[] { "progrix" }, tb17);
            /*
            string openingtype = uixlocal_readopeningtype(tundrixtext, ref xx, false, new string[] { "progrix" });
            MessageBox.Show("openingtype: \"" + openingtype+"\"");
            string[] errors = { "undefinedanswer", "variety", "eos" };
            if (!uixlocal_inastring(openingtype, errors))
            {
                tundrable statictundrable = null;
                for (int i = 0; i < static_atundrableobjects.Length; i++)
                {
                    if (static_atundrableobjects[i].static_getxtype == openingtype)
                    {
                        statictundrable = static_atundrableobjects[i];
                    }
                }
                if (statictundrable != null)
                { 
                    uixlocal_relativeread()
                }
            }
            */
            return tundrableobject;
        }

        class progrix : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*program*/
        {
            tunstruction tuns = null;
            public progrix(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
            string[] nestedxtypes = new string[] { "progrix", "tuntributix", "vardeclarix", "blox" };
            string this_xtype = "progrix";
            string[] openingkeys = new string[] { "progrix." };
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }

            public string spec_readprogrixname(string tundrixtext, ref int caretposition)
            {
                int stage = 0;
                string res = "";
                while(stage<2)
                {
                    char c=tundrixtext[caretposition];
                    if (stage==0)
                    {
                        if(!tuns.uixlocal_dotequivalent(c))
                        {
                            stage=1;
                        }
                    }
                    if (stage==1)
                    {
                        if (tuns.uixlocal_dotequivalent(c))
                        {
                            stage = 2;
                        }
                        else
                        {
                            res += c;
                        }
                    }
                    if (stage==2)
                    {
                        if(!tuns.uixlocal_dotequivalent(c))
                        {
                            stage=3;
                        }
                    }
                    caretposition++;
                }
                return res;
            }
        }
        class clax : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*class*/
        {tunstruction tuns = null;
            public clax(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class fundrix : tundrable, valuable, insetting, mustliveasstatementline, canliveasstatementline
        /*function*/
        {tunstruction tuns = null;
            public fundrix(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class voidrix : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*procedure*/
        {tunstruction tuns = null;
            public voidrix(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class blox : tundrable, insetting, mustliveasstatementline, canliveasstatementline
        /*{...}*/
        {tunstruction tuns = null;
            public blox(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            bool tundrable.static_istundrixdatatype() { return false; }
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            tundrable[] insetting.getnclist() { return nclist; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class commix : tundrable, canliveasstatementline
        // /*+ */
        {tunstruction tuns = null;
            public commix(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class tuntributix : tundrable, mustliveasstatementline, canliveasstatementline
        // /*+ */
        {
            tunstruction tuns = null;
            public tuntributix(tunstruction _tuns)
            {
                tuns = _tuns;
            }
            //tundrable[] nclist = new tundrable[0];
            tundrable master = null;

            string this_xtype = "tuntributix";
            string[] openingkeys = new string[] { "[," };
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }

            public string spec_tuntributix(string tundrixtext, ref int caretposition)
            {
                int stage = 0;
                string res = "";
                char c = 'x';
                while (c != ']')
                {
                    c = tundrixtext[caretposition];
                    if (c != ']')
                        res += c;
                    caretposition++;
                }
                return res;
            }
        }  
        class rux : tundrable, valuable
        /*pd byte - platform dependent byte*/
        {tunstruction tuns = null;
            public rux(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }
        class vardeclarix : tundrable, variabledeclaration, mustliveasstatementline, canliveasstatementline
        /*pd byte - platform dependent byte*/
        {tunstruction tuns = null;
            public vardeclarix(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
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
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
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
        {tunstruction tuns = null;
        public varblox(tunstruction _tuns)
            {                
                tuns = _tuns;
            }
            tundrable[] nclist = new tundrable[0];
            string[] nestedxtypes = new string[] { "bux",
            "rux", "drux", "qrux", "orux", 
            "srux", "sdrux", "sqrux", "sorux", 
            "rox",
            "fux", "dfux", "xfux", 
            "strinx", "sbrinx",
            "memdrix" };
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
            void insetting.addtundrable(tundrable t) { nclist = uix_addtundrable(nclist, t); }
            tundrable[] insetting.getnclist() { return nclist; }
            string[] insetting.static_getnestedxtypes() { return nestedxtypes; }
            bool tundrable.static_istundrixdatatype() { return false; }
            string[] tundrable.static_gettunstructioninterfaces() { return tunstructioninterfaces; }
            bool tundrable.static_hasinterface(string tunstructioninterface) { return uixlocal_inastring(tunstructioninterface, tunstructioninterfaces); }
            int tundrable.static_isopeningkey(string stringword) { return tuns.uix_isopeningkey(stringword, openingkeys); }
            tundrable tundrable.getmasterobject() { return master; }
            void tundrable.setmasterobject(tundrable masterobject) { master = masterobject; }
        }     
    }
}
