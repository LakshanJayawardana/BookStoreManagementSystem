using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class BookController : Controller
{
    private IBookRepository _bookRepository;
    private IPhotoService _photoService;
    public BookController(IBookRepository bookRepository, IPhotoService photoService)
    {
        _bookRepository = bookRepository;
        _photoService = photoService;
    }

    public IActionResult AllBookList()
    {
        var books = _bookRepository.GetAllBooks();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }
    // public IActionResult Edit()
    // {
    //     return View();
    // }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookViewModel bookVM)
    {
        //var result = await _photoService.AddPhotoAsync(bookVM.Image);
        var book = new BooksEntity
            {
                Title = bookVM.Title,
                ISBN = bookVM.ISBN,
                NumberOfPages = bookVM.NumberOfPages,
                PublicationDate = bookVM.PublicationDate,
                PublisherId = bookVM.PublisherId,
                LanguageId = bookVM.LanguageId,
                //ImageUrl = result.Url.ToString()
            };
            _bookRepository.CreateBook(book);
            return RedirectToAction("AllBookList");  
        //if (ModelState.IsValid)
        //{      
        //}
        //else
        //{
        //   ModelState.AddModelError("", "Photo upload failed");
        //}
        //return View(bookVM);
        //return RedirectToAction("AllBookList");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _bookRepository.GetBookById(id);
        if (book == null)
        {
            return View("Error");
        }
        var bookVM = new UpdateBookViewModel
        {
            Title = book.Title,
            ISBN = book.ISBN,
            NumberOfPages = book.NumberOfPages,
            PublicationDate = book.PublicationDate,
            PublisherId = book.PublisherId,
            LanguageId = book.LanguageId,
            ImageUrl = book.ImageUrl
        };
        return View(bookVM);
        //_bookRepository.UpdateBook(book);
        //return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateBookViewModel bookVM)
    {
        ModelState.Clear();
        // if(!ModelState.IsValid)
        // {
        //     ModelState.AddModelError("", "Failled to Edit");
        //     //return RedirectToAction("AllBookList");
        //     return View("Edit", bookVM);
        // }
        //var book = _bookRepository.GetBookById(id);
        var book = new BooksEntity
        {
            Title = bookVM.Title,
            ISBN = bookVM.ISBN,
            NumberOfPages = bookVM.NumberOfPages,
            PublicationDate = bookVM.PublicationDate,
            PublisherId = bookVM.PublisherId,
            LanguageId = bookVM.LanguageId,
            //ImageUrl = result.Url.ToString()
        };
        _bookRepository.UpdateBook(book);
        return RedirectToAction("AllBookList");
    }
    public IActionResult Detail(int id)
    {
        var bookDetail = _bookRepository.GetBookById(id);

        return View(bookDetail);
    }


}