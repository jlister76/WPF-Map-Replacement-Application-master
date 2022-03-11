﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FSV42_FullMapReplacement
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="map_updates")]
	public partial class MUDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertatmos_mapupdate(atmos_mapupdate instance);
    partial void Updateatmos_mapupdate(atmos_mapupdate instance);
    partial void Deleteatmos_mapupdate(atmos_mapupdate instance);
    #endregion
		
		public MUDataClassesDataContext() : 
				base(global::FSV42_FullMapReplacement.Properties.Settings.Default.map_updatesConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MUDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MUDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MUDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MUDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<atmos_mapupdate> atmos_mapupdates
		{
			get
			{
				return this.GetTable<atmos_mapupdate>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.atmos_mapupdate")]
	public partial class atmos_mapupdate : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.DateTime _date;
		
		private string _region;
		
		private string _computer_name;
		
		private string _username;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OndateChanging(System.DateTime value);
    partial void OndateChanged();
    partial void OnregionChanging(string value);
    partial void OnregionChanged();
    partial void Oncomputer_nameChanging(string value);
    partial void Oncomputer_nameChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    #endregion
		
		public atmos_mapupdate()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime NOT NULL")]
		public System.DateTime date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_region", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string region
		{
			get
			{
				return this._region;
			}
			set
			{
				if ((this._region != value))
				{
					this.OnregionChanging(value);
					this.SendPropertyChanging();
					this._region = value;
					this.SendPropertyChanged("region");
					this.OnregionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_computer_name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string computer_name
		{
			get
			{
				return this._computer_name;
			}
			set
			{
				if ((this._computer_name != value))
				{
					this.Oncomputer_nameChanging(value);
					this.SendPropertyChanging();
					this._computer_name = value;
					this.SendPropertyChanged("computer_name");
					this.Oncomputer_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
