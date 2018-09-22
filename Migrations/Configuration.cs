using Microsoft.Ajax.Utilities;
using MusicStore.Models;

namespace MusicStore.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<MusicDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(MusicDb context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			context.Musics.AddOrUpdate(
			  m => m.Title,
			  new Music
			  {
				  Title = "Man Ki Mat Pe Mat Chaliyo",
				  Singers = "Rahat Fateh Ali Khan",
				  RunTime = 5,
				  ReleaseDate = new DateTime(2016, 01, 02)
			  },
			   new Music
			   {
				   Title = "Tere Mast Mast Do Nain",
				   Singers = "Shreya Ghoshal, Rahat Fateh Ali Khan",
				   RunTime = 5,
				   ReleaseDate = new DateTime(2016, 01, 02)
			   },
			   new Music
			   {
				   Title = "Dil Ho Gaya Shanty Flat",
				   Singers = "Kishore Kumar",
				   RunTime = 5,
				   ReleaseDate = new DateTime(2016, 01, 02)
			   },
			   new Music
			   {
				   Title = "Humka Peeni Hai Peeni",
				   Singers = "Wajid, Master Salim, Shabab Sabri",
				   RunTime = 5,
				   ReleaseDate = new DateTime(2016, 01, 02)
			   },
			   new Music
			   {
				   Title = "Pee Loon Hoto Ki Sargam",
				   Singers = "Mohit Chauhan",
				   RunTime = 5,
				   ReleaseDate = new DateTime(2016, 01, 02)
			   }
			);
		}
	}
}
