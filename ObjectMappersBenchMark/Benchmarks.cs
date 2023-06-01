using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using Nelibur.ObjectMapper;
using ObjectMappersBenchMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMappersBenchMark;

[MemoryDiagnoser(false)]
public class Benchmarks
{
	EmployeeDTO _employeeDTO;
	private readonly IMapper _autoMapper;
	private readonly MapperlyMapper _mapperlyMapper;
	public Benchmarks()
	{
		//AutoMapper Config
		var mapperConfig = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<EmployeeDTO, Employee>();
			cfg.CreateMap<AddressDTO,Address>();
			cfg.CreateMap<Employee, EmployeeDTO>();
			cfg.CreateMap<Address, AddressDTO>();
		});
		_autoMapper = mapperConfig.CreateMapper();

		//Tiny Mapper configuration
		TinyMapper.Bind<EmployeeDTO, Employee>();
		TinyMapper.Bind<AddressDTO, Address>();
		TinyMapper.Bind<Employee, EmployeeDTO>();
		TinyMapper.Bind<Address, AddressDTO>();

		//MapperlyMapper
		_mapperlyMapper = new MapperlyMapper();

		//Mapster: No need of mapping necessary
	}

	[GlobalSetup]
	public void SetupInitialData()
	{
		_employeeDTO = new EmployeeDTO()
		{
			FirstName = "John",
			LastName = "Wick",
			EmployeeId = "JW123",
			Email = "johnwick@company.com",
			DateOfJoin = new DateTime(2020, 1, 16),
			YearsOfExperience = 4,
			Skills = new[] { "C#", "SQL Server", "Azure", "AWS" },
			Address = new AddressDTO()
			{
				Street = "80 Main Street",
				ApartmentOrSuiteNo = "A",
				City = "Manchester",
				State = "CT",
				ZipCode = "06042"
			}
		};		
	}

	[Benchmark]
	public Employee AutoMapperMethod()
	{
		Employee mappedEmployee = _autoMapper.Map<Employee>(_employeeDTO);
		return mappedEmployee;
	}

	[Benchmark]
	public Employee TinyMapperMethod()
	{
		Employee tinyMappedEmployee =TinyMapper.Map<Employee>(_employeeDTO);
		return tinyMappedEmployee;
	}
	[Benchmark]
	public Employee MapperlyMethod()
	{
		Employee mapperlyEmp = _mapperlyMapper.Map(_employeeDTO);
		return mapperlyEmp;
	}
	[Benchmark]
	public Employee Mapster()
	{
		Employee mapsterMappedEmp = _employeeDTO.Adapt<Employee>();
		return mapsterMappedEmp;
	}
}
