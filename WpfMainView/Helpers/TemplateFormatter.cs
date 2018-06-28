using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMainView.Helpers
{
    class TemplateFormatter
    {
        public TemplateContent Content { get; set; }

        // Constructor
        public TemplateFormatter(TemplateContent content)
        {
            Content = content;
        }

        private string ToLatex(Package p)
        {
            string o = "";
            o += "\\usepackage{" + p.Nom + "}";
            //if (String.IsNullOrEmpty(p.Desc))
            //{
            //    o += " %% " + p.Desc;
            //}

            o += "\n";

            return o;
        }

        private string ToLatex(Macro m)
        {
            string output = "\\newcommand\\" + m.Nom + "{";
            output += m.Code;
            output += "}";
            if (!String.IsNullOrEmpty(m.Desc))
            {
                output += " %% " + m.Desc;
            }
            output += "\n";
            return output;
        }

        private string ToLatex(LTG_Entity.Environment e)
        {
            string output = "\\newenvironment\\" + e.Nom + "{";
            if (!String.IsNullOrEmpty(e.Desc))
            {
                output += " %% " + e.Desc;
            }
            output += "\n";
            output += "  " + e.CodeBefore.Replace("\n", "\n" + "  ");
            output += "\n}\n{\n";
            output += "  " + e.CodeAfter.Replace("\n", "\n" + "  ");
            output += "\n}\n";
            return output;
        }

        private string docClass()
        {
            string output = "";
            output += "\\documentclass{";
            switch (Content.DocType.Nom)
            {
                
                case "Beamer":
                    output += "beamer";
                    break;
                case "Book":
                    output += "book";
                    break;
                case "CV":
                    output += "moderncv";
                    break;
                case "Letter":
                    output += "letter";
                    break;
                case "Article":
                default:
                    output += "article";
                    break;
            }

            output += "}\n\n";

            return output;
        }

        private string Language()
        {
            string output = "%% Options de langue\n";

            output += "\\usepackage[";

            switch (Content.Langue.Nom)
            {
                case "Anglais":
                    output += "english";
                    break;
                case "Français":
                default:
                    output += "francais";
                    break;
            }

            output += "]{babel}\n\n";
            return output;

        }


        public string generate()
        {
            
            string output = "%% Template generatö par LaTeXPlate\n";
            output += "%% le " + DateTime.Today.ToShortDateString() + "\n\n";

            output += DescBox();

            output += docClass();
            output += Language();

            // List of packages
            output += FormatPackages();



            // List of macros
            if (Content.AddedMacros.Count() > 0)
            {
                output += "\n\n%%%%%%%%%%%%%%%%%%%%%";
                output += "\n%% Liste des macros %\n";
                output += "%%%%%%%%%%%%%%%%%%%%%\n";

            }
            foreach (Macro m in Content.AddedMacros)
            {
                output += ToLatex(m);
            }

            // List of environments
            if (Content.AddedEnv.Count() > 0)
            {
                output += "\n\n%%%%%%%%%%%%%%%%%%%%%%%%%%%";
                output += "\n%% Liste des environments %\n";
                output += "%%%%%%%%%%%%%%%%%%%%%%%%%%%\n";
            }
            foreach (LTG_Entity.Environment e in Content.AddedEnv)
            {
                output += ToLatex(e);
            }
            // Main doc

            output += "\n\n\\begin{docuent}\n\n\\end{document}";

            return output;
        }

        private string DescBox()
        {
            string output = "";

            if (Content.CurrentTemplate.Desc != null)
            {
                // Above starred row
                for (int i = 0; i < Content.CurrentTemplate.Desc.Length + 4; i++)
                {
                    output += "%";
                }

                // Above empty row
                output += "\n%";
                for (int i = 0; i < Content.CurrentTemplate.Desc.Length + 2; i++)
                {
                    output += " ";
                }

                // Description insert
                output += "%\n% ";
                output += Content.CurrentTemplate.Desc + " %\n%";

                // Below empty row
                for (int i = 0; i < Content.CurrentTemplate.Desc.Length + 2; i++)
                {
                    output += " ";
                }

                // Below starred row
                output += "%\n";

                for (int i = 0; i < Content.CurrentTemplate.Desc.Length + 4; i++)
                {
                    output += "%";
                }

                output += "\n\n";
            }

            return output;
        }

        private string FormatPackages()
        {
            string output = "";

            if (Content.AddedPackages.Count() > 0)
            {
                output += "\n\n%%%%%%%%%%%%%%%%%%%%%%%";
                output += "\n%% Liste des packages %\n";
                output += "%%%%%%%%%%%%%%%%%%%%%%%\n";
            }

            // Encoding option
            if (Content.CurrentTemplate.Encoding.Value)
            {
                output += "\\usepackage[utf8]{inputenc}\n" +
                    "\\usepackage[T1]{fontenc}\n";
            }

            

            foreach (Package p in Content.AddedPackages)
            {
                output += ToLatex(p);
            }

            // Hyperref option
            if (Content.CurrentTemplate.Hyperref.Value)
            {
                output += "\\usepackage{hyperref}";
            }

            return output;

        }
    }
}
