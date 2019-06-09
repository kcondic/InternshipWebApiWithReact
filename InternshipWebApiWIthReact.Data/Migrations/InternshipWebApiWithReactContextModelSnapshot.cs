﻿// <auto-generated />
using System;
using InternshipWebApiWithReact.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternshipWebApiWithReact.Data.Migrations
{
    [DbContext(typeof(InternshipWebApiWithReactContext))]
    partial class InternshipWebApiWithReactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DestinationAirportId");

                    b.Property<int?>("PlaneId");

                    b.Property<int?>("SourceAirportId");

                    b.Property<DateTime>("TimeOfFlight");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DestinationAirportId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("SourceAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<int>("FlightPoints");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.PassengerFlight", b =>
                {
                    b.Property<int>("PassengerId");

                    b.Property<int>("FlightId");

                    b.Property<string>("SeatNumber");

                    b.HasKey("PassengerId", "FlightId");

                    b.HasIndex("FlightId");

                    b.ToTable("PassengerFlights");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carrier");

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.Flight", b =>
                {
                    b.HasOne("InternshipWebApiWithReact.Data.Models.Entities.Airport", "DestinationAirport")
                        .WithMany("ToFlights")
                        .HasForeignKey("DestinationAirportId");

                    b.HasOne("InternshipWebApiWithReact.Data.Models.Entities.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId");

                    b.HasOne("InternshipWebApiWithReact.Data.Models.Entities.Airport", "SourceAirport")
                        .WithMany("FromFlights")
                        .HasForeignKey("SourceAirportId");
                });

            modelBuilder.Entity("InternshipWebApiWithReact.Data.Models.Entities.PassengerFlight", b =>
                {
                    b.HasOne("InternshipWebApiWithReact.Data.Models.Entities.Flight", "Flight")
                        .WithMany("PassengerFlights")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternshipWebApiWithReact.Data.Models.Entities.Passenger", "Passenger")
                        .WithMany("PassengerFlights")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
