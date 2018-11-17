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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolutionFile solutionFile = new SolutionFile(textBox1.Text);
            treeView1.Nodes.Clear();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            if (!solutionFile.Load())
                return;

            Solution solution = solutionFile.Solution;
            TreeNode root = treeView1.Nodes.Add(solution.Name);
            root.Tag = solution;

            TreeNode platformsNode = root.Nodes.Add("Platforms");
            foreach(Platform platform in solution.Platforms)
            {
                TreeNode newNode = platformsNode.Nodes.Add(platform.Name);
                newNode.Tag = platform;
            }

            TreeNode configsNode = root.Nodes.Add("Configurations");
            foreach (Configuration configuration in solution.Configurations)
            {
                TreeNode newNode = configsNode.Nodes.Add(configuration.Name);
                newNode.Tag = configuration;
            }

            TreeNode prjsNode = root.Nodes.Add("Projects");
            foreach (Project project in solution.Projects)
            {
                TreeNode prjNode = prjsNode.Nodes.Add(project.Name);
                prjNode.Tag = project;

                TreeNode platforms = prjNode.Nodes.Add("Plarforms");
                foreach(Platform platform in project.Platforms)
                {
                    TreeNode newNode = platforms.Nodes.Add(platform.Name);
                    newNode.Tag = platform;
                }

                TreeNode configs = prjNode.Nodes.Add("Configurations");
                foreach (Configuration configuration in project.Configurations)
                {
                    TreeNode newNode = configs.Nodes.Add(configuration.Name);
                    newNode.Tag = configuration;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();

            //

        }
    }
}
