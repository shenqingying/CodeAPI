using Sonluk.DAFactory;
using Sonluk.Entities.Print;
using Sonluk.IDataAccess.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Print
{
    public class Layout
    {
        private static readonly ILayout detaAccess = PrintDataAccess.CreateLayout();

        public int Create(LayoutInfo node)
        {
            int ID = detaAccess.Create(node);
            if (ID > 0)
            {
                Control childrenBL = new Control();
                int length = node.Controls.Count;
                if (length > 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        if (node.Controls[i].Type != null && !node.Controls[i].Type.Equals("del"))
                        {
                            node.Controls[i].Layout = ID;
                            childrenBL.Create(node.Controls[i]);
                        }
                        
                    }
                }
            }
            return ID;
        }

        public bool Update(LayoutInfo node)
        {
            bool achieve = detaAccess.Update(node);

            if (achieve)
            {
                Control childrenBL = new Control();
                int length = node.Controls.Count;
                if (length > 0)
                {
                    for (int i = 0; i < length; i++)
                    {  
                        if (node.Controls[i].ID > 0)
                        {
                            if (node.Controls[i].Type.Equals("del"))
                                childrenBL.Delete(node.Controls[i].ID);
                            else 
                                childrenBL.Update(node.Controls[i]);
                        }
                        else
                        {
                            if (node.Controls[i].Type != null && !node.Controls[i].Type.Equals("del"))
                            {
                                node.Controls[i].Layout = node.ID;
                                childrenBL.Create(node.Controls[i]);
                            }
                        } 
                    }
                }
            }
            return achieve;
        }

        public IList<LayoutInfo> Read()
        {
            IList<LayoutInfo> nodes = detaAccess.Read();
            int length = nodes.Count;

            if (length > 0)
            {
                Control childrenBL = new Control();
                for (int i = 0; i < length; i++)
                {
                    nodes[i].Controls = childrenBL.Read(nodes[i].ID).ToList();
                }
            }

            return nodes;
        }

        public LayoutInfo Read(int ID)
        {
            LayoutInfo node = detaAccess.Read(ID);

            if (node.ID > 0)
            {
                Control childrenBL = new Control();
                node.Controls = childrenBL.Read(node.ID).ToList();
            }
            return node;
        }

        public LayoutInfo Read(string Doc, string Mac)
        {
            LayoutInfo node = detaAccess.Read(Doc,Mac);

            if (node.ID > 0)
            {
                Control childrenBL = new Control();
                node.Controls = childrenBL.Read(node.ID).ToList();
            }
            else
            {
                node.Controls = new List<ControlInfo>();
            }
            return node;
        }

        public bool Delete(int ID)
        {
            return detaAccess.Delete(ID);
        }
    }
}
