﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conduit
{
  public partial class OptionsDialog : Form
  {
    public OptionsDialog()
    {
      InitializeComponent();
    }

    public DialogResult ShowDialogWithOpenTab(string tab)
    {
      tabControl1.SelectTab(tab);
      return ShowDialog();
    }

    private void OptionsDialog_Load(object sender, EventArgs e)
    {
      textDemoPath.Text = Settings.Options.DemoPath;
      textVicePath.Text = Settings.Options.VicePath;
      textDosboxPath.Text = Settings.Options.DOSBoxPath;
      textBrowserPath.Text = Settings.Options.BrowserPath;
      checkBoxBrowserAddFlag.Checked = Settings.Options.BrowserAddFileAccessFlag;
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      Settings.Options.DemoPath = textDemoPath.Text;
      Settings.Options.VicePath = textVicePath.Text;
      Settings.Options.DOSBoxPath = textDosboxPath.Text;
      Settings.Options.BrowserPath = textBrowserPath.Text;
      Settings.Options.BrowserAddFileAccessFlag = checkBoxBrowserAddFlag.Checked;
      Settings.SaveSettings();
      DialogResult = DialogResult.OK;
    }

    private void butBrowseVICE_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();

      ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
      ofd.Filter = "WinVICE executables (x64*.exe)|x64*.exe|All executables (*.exe)|*.exe";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        textVicePath.Text = ofd.FileName;
      }
    }

    private void butBrowseDosbox_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();

      ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
      ofd.Filter = "DOSBox executable (DOSBox.exe)|DOSBox.exe|All executables (*.exe)|*.exe";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        textDosboxPath.Text = ofd.FileName;
      }
    }

    private void butBrowserPathBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();

      ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
      ofd.Filter = "Browser executable (*.exe)|*.exe";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        textBrowserPath.Text = ofd.FileName;
      }
    }
  }
}
