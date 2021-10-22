﻿// <auto-generated />
using System;
using ImageGram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageGram.Infrastructure.Migrations
{
    [DbContext(typeof(ImageGramDBContext))]
    partial class ImageGramDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ImageGram.Infrastructure.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentPostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ImageGram.Infrastructure.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("AttachedImage")
                        .HasColumnType("BLOB");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ImageGram.Infrastructure.Entities.Comment", b =>
                {
                    b.HasOne("ImageGram.Infrastructure.Entities.Post", "ParentPost")
                        .WithMany("Comments")
                        .HasForeignKey("ParentPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentPost");
                });

            modelBuilder.Entity("ImageGram.Infrastructure.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}