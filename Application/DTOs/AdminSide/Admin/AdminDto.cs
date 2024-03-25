﻿

namespace Application.DTOs.AdminSide.Admin;

public class AdminDto
{
	public int Id { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public DateTime DateTime { get; set; } = DateTime.Now;
	public string? UserAvatar { get; set; }
	public bool IsAdmin { get; set; }
	public bool SuperAdmin { get; set; }
}
