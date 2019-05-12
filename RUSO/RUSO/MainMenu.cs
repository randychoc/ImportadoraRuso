﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RUSO
{
	public partial class MainMenu : Form
	{
		string usuario;
		string level;
		public MainMenu(string user, string nivel)
		{
			InitializeComponent();
			usuario = user;
			level = nivel;
			label1.Text = user;
		}

		void log(string queryin)
		{
			MySqlConnection databaseConnection = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username =root; password =; database =montreal");
			string query = "INSERT INTO log (Usuario,operacion,fecha) VALUES ('" + usuario + "','" + queryin + "','" + DateTime.Now.ToString("G") + "')";
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{

				consulta.ExecuteNonQuery();
				databaseConnection.Close();

			}
			catch (Exception ex)
			{
	 			databaseConnection.Close();
			}
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{

		}

		private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Hide();
			LogIn nuevoLogin = new LogIn();
			nuevoLogin.Show();
		}

		private void button1_MouseHover(object sender, EventArgs e)
		{
			button1.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button1.Text = "VEHICULOS";
		}

		private void button1_MouseLeave(object sender, EventArgs e)
		{
			button1.BackgroundImage = global::RUSO.Properties.Resources.car;
			button1.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Opcion op1 = new Opcion();
			op1.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Taller op1 = new Taller(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button2_MouseHover(object sender, EventArgs e)
		{
			button2.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button2.Text = "TALLERES";
		}

		private void button2_MouseLeave(object sender, EventArgs e)
		{
			button2.BackgroundImage = global::RUSO.Properties.Resources.taller;
			button2.Text = "";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label2.Text = DateTime.Now.ToLongTimeString();
		}
	}
}
