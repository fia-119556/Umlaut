namespace Umlaut
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hookStartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hookEndMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.ContextMenuStrip = this.contextMenuStrip;
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "ウムラウト入力";
            this.icon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hookStartMenuItem,
            this.hookEndMenuItem,
            this.exitMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(143, 70);
            // 
            // hookStartMenuItem
            // 
            this.hookStartMenuItem.Name = "hookStartMenuItem";
            this.hookStartMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hookStartMenuItem.Text = "フック開始";
            this.hookStartMenuItem.Click += new System.EventHandler(this.hookStartMenuItem_Click);
            // 
            // hookEndMenuItem
            // 
            this.hookEndMenuItem.Name = "hookEndMenuItem";
            this.hookEndMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hookEndMenuItem.Text = "フック終了";
            this.hookEndMenuItem.Click += new System.EventHandler(this.hookEndMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitMenuItem.Text = "プログラム終了";
            this.exitMenuItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Form";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem hookStartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hookEndMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    }
}

