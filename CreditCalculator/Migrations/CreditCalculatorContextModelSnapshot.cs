// <auto-generated />
using System;
using CreditCalculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditCalculator.Migrations
{
    [DbContext(typeof(CreditCalculatorContext))]
    partial class CreditCalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CreditCalculator.Models.CreditCalculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AnnualInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MonthlyTerm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CreditCalculations");
                });

            modelBuilder.Entity("CreditCalculator.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BodySum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreditCalculationId")
                        .HasColumnType("int");

                    b.Property<decimal>("DebtBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MarginSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditCalculationId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CreditCalculator.Models.Payment", b =>
                {
                    b.HasOne("CreditCalculator.Models.CreditCalculation", "CreditCalculation")
                        .WithMany()
                        .HasForeignKey("CreditCalculationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCalculation");
                });
#pragma warning restore 612, 618
        }
    }
}
