﻿using DbProject.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
	public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
	{
		public abstract void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
