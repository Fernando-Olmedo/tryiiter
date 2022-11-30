using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tryiiter.Models;
using tryiiter.Repository;

namespace tryiiter.Controllers;

public class TryiiterController : Controller
{
    private readonly TryiiterContext _context;
    public TryiiterController(TryiiterContext context)
    {
        _context = context;
    }
}
