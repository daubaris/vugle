﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VugleBE.Context;

namespace VugleBE.Migrations
{
    [DbContext(typeof(VugleContext))]
    partial class VugleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("VugleBE.Context.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PollId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("VugleBE.Context.Models.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("VugleBE.Context.Models.PollResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PollId");

                    b.Property<string>("Response");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("PollResponses");
                });

            modelBuilder.Entity("VugleBE.Context.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VugleBE.Context.Models.Option", b =>
                {
                    b.HasOne("VugleBE.Context.Models.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VugleBE.Context.Models.PollResponse", b =>
                {
                    b.HasOne("VugleBE.Context.Models.Poll", "Poll")
                        .WithMany("PollResponses")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VugleBE.Context.Models.User", "User")
                        .WithMany("PollResponses")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
