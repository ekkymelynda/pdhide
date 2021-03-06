﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatternDesigner.Colom;

namespace PatternDesigner.Commands
{
    public class ApplyClassProperties : Command
    {
        private Vertex vertex;
        private string oldName;
        private string newName;
        private List<Method> oldMethod = new List<Method>();
        private List<Attribute> oldAttribute =  new List<Attribute>();
        private List<Method> newMethod = new List<Method>();
        private List<Attribute> newAttribute = new List<Attribute>();
        public ApplyClassProperties(ICanvas canvas, Vertex vertex, string newName, string oldName, List<Method> meth, List<Attribute> att, List<Baris> listBaris, List<Baris> listBarisMethod, int i, int j)
        {
            this.vertex = vertex;
            this.canvas = canvas;
            this.oldName = oldName;
            this.newName = newName;
            Debug.WriteLine("i,j = " + i + j);

            if (att.Count() != 0)
            {
                foreach (Attribute a in att)
                {
                    oldAttribute.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            if (meth.Count() != 0)
            {
                foreach (Method b in meth)
                {
                    oldMethod.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }

            if (i > 0)
            {
                for (int a = 0; a < i; a++)
                {
                    newAttribute.Add(new Attribute() { visibility = ((DropdownColom)listBaris[a].kolom[0]).dropDown.Text, nama = ((KotakInput)listBaris[a].kolom[1]).kotak.Text, tipe = ((KotakInput)listBaris[a].kolom[2]).kotak.Text });
                }
            }

            if (j > 0)
            {
                for (int b = 0; b < j; b++)
                {
                    newMethod.Add(new Method() { visibility = ((DropdownColom)listBarisMethod[b].kolom[0]).dropDown.Text, nama = ((KotakInput)listBarisMethod[b].kolom[1]).kotak.Text, tipe = ((KotakInput)listBarisMethod[b].kolom[2]).kotak.Text });
                }
            }

            removeRedoStack();
        }

        public override void Execute()
        {
            vertex.nama = newName;

            vertex.att.Clear();
            if (newAttribute.Count() != 0)
            {
                foreach (Attribute a in newAttribute)
                {
                    vertex.att.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            vertex.meth.Clear();
            if (newMethod.Count() != 0)
            {
                foreach (Method b in newMethod)
                {
                    vertex.meth.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }
        }

        public override void Unexecute()
        {
            vertex.nama = oldName;
    
            vertex.att.Clear();
            if (oldAttribute.Count() != 0)
            {
                foreach (Attribute a in oldAttribute)
                {
                    vertex.att.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            vertex.meth.Clear();

            if (oldMethod.Count() != 0)
            {
                foreach (Method b in oldMethod)
                {
                    vertex.meth.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }

        }
    }
}
