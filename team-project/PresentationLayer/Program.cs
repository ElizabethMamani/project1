// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add connection string
ConnectionInfoSQL connectionInfoSQL = builder.Configuration.GetSection("ConnectionInfoSQL").Get<ConnectionInfoSQL>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IDataAccessCourses, DataAccessCourses>(x => new DataAccessCourses(connectionInfoSQL));

builder.Services.AddScoped<IServiceSubject, SubjectService>();
builder.Services.AddScoped<IDataAccessSubjects, DataAccessSubjects>(x => new DataAccessSubjects(connectionInfoSQL));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDataAccessStudents, DataAccessStudents>(x => new DataAccessStudents(connectionInfoSQL));
builder.Services.AddCors(policy => policy.AddDefaultPolicy(builder =>
{
    builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
