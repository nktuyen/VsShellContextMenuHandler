using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vs;

namespace Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void InsertModel(Model model, TreeNode treeNode)
        {
            TreeNode newNode = treeNode.Nodes.Add(model.Name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolutionFile solutionFile = new SolutionFile(textBox1.Text);
            treeView1.Nodes.Clear();
            if (!solutionFile.Load())
                return;

            Solution solution = solutionFile.Solution;
            TreeNode root = treeView1.Nodes.Add(solution.Name);
            root.Tag = solution;

            foreach (Project project in solution.Projects)
            {
                InsertModel(project, root);
            }
        }
    }
}
