using HealthcareManagementApplication.Data;
using HealthcareManagementApplication.Models;
using HealthcareManagementApplication.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareTests
{
    public class PatientControllerTests
    {
        private HealthcareManagementDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<HealthcareManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "HealthcareManagementDb_Test")
                .Options;

            return new HealthcareManagementDbContext(options);
        }

        [Fact]
        public async Task GetPatients_ShouldReturnAllPatients()
        {
            await using var context = GetInMemoryDbContext();
            var testPatient1 = new Patient
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com"
            };
            var testPatient2 = new Patient
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = "456 Elm St",
                DateOfBirth = new DateTime(1985, 6, 15),
                Gender = "Female",
                PhoneNumber = "9876543210",
                Email = "jane.doe@example.com"
            };

            context.Patients.Add(testPatient1);
            context.Patients.Add(testPatient2);
            await context.SaveChangesAsync();

            var controller = new PatientController(context);

            // Act
            var patients = (await controller.GetPatients()).Value.ToList();

            // Assert
            Assert.Equal(2, patients.Count);
            Assert.Equal("John", patients[0].FirstName);
            Assert.Equal("Doe", patients[0].LastName);
            Assert.Equal("Jane", patients[1].FirstName);
            Assert.Equal("Doe", patients[1].LastName);
        }

        [Fact]
        public async Task GetPatient_ShouldReturnPatientById()
        {
            // Arrange
            await using var context = GetInMemoryDbContext();
            var testPatient = new Patient
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com"
            };
            await context.Patients.AddAsync(testPatient);
            await context.SaveChangesAsync();

            var controller = new PatientController(context);

            // Act
            var result = await controller.GetPatient(testPatient.Id);

            // Assert
            var patient = Assert.IsType<Patient>(result.Value);
            Assert.Equal(testPatient.Id, patient.Id);
            Assert.Equal(testPatient.FirstName, patient.FirstName);
            Assert.Equal(testPatient.LastName, patient.LastName);
        }

        [Fact]
        public async Task UpdatePatient_ShouldUpdateExistingPatient()
        {
            // Arrange
            await using var initialContext = GetInMemoryDbContext();
            var testPatient = new Patient
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com"
            };
            await initialContext.Patients.AddAsync(testPatient);
            await initialContext.SaveChangesAsync();

            var updatedPatient = new Patient
            {
                Id = testPatient.Id,
                FirstName = "John",
                LastName = "Doe",
                Address = "456 Oak St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com"
            };

            // Create a new context for the PatientController
            await using var context = GetInMemoryDbContext();
            var controller = new PatientController(context);

            // Act
            var result = await controller.UpdatePatient(testPatient.Id, updatedPatient);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var retrievedPatient = await context.Patients.FindAsync(testPatient.Id);
            Assert.Equal(updatedPatient.Address, retrievedPatient.Address);
        }
    }
}