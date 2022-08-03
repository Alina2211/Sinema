using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sinema.ViewModels;
using Sinema.Models;
using System.Text.Json;


namespace Sinema.Controllers
{
    public class FilmController : Controller
    {
        private readonly sinemaContext db;
        public FilmController (sinemaContext _db)
        {
            db = _db;
        }
        public IActionResult FilmTable()
        {
            var films = db.Films.ToList();
            List<FilmViewModel> filmList = new List<FilmViewModel>();
            
            foreach (var f in films)
            {
                var actorFilms = f.ActorFilms;
                List<Actor> actors = new List<Actor>();
                foreach (var fl in actorFilms)
                {
                    actors.Add(fl.Actor);
                }
                FilmViewModel curFilm = new FilmViewModel
                {
                    FilmId = f.Id,
                    FilmName = f.FilmName,
                    Duration = f.Duration,
                    Director = f.Director,
                    Genre = f.Genre,
                    Rating = f.Rating,
                    Poster = f.Poster,
                    Actors = actors
                };
                filmList.Add(curFilm);
            }
            
            return View(filmList);
        } 

        public IActionResult FilmPage(int? id)
        {
            ViewBag.i = 0;
            if (id != null)
            {
                
                var film = db.Films.Where(p => p.Id == id).FirstOrDefault();
                var filmActors = film.ActorFilms;
                List<Actor> actors = new List<Actor>();
                foreach(var actor in filmActors)
                {
                    actors.Add(actor.Actor);
                }
                
                var sessions = film.Schedules.OrderBy(p=>p.FilmSession).ToList();

                FilmViewModel curFilm = new FilmViewModel
                {
                    FilmId = film.Id,
                    FilmName = film.FilmName,
                    Duration = film.Duration,
                    Director = film.Director,
                    Genre = film.Genre,
                    Rating = film.Rating,
                    Poster = film.Poster,
                    Actors = actors,
                    Sessions = sessions
                };
                return View(curFilm);
            }
            return View("Error");
            
        }

        public IActionResult ShowSinemaRoom(Schedule session, string filmName) //передается id сеанса
        {
            ViewBag.Session = session;
            ViewBag.FilmName = filmName;
            List<PlaceSession> places = db.PlaceSessions.Where(p => p.ScheduleId == session.Id).OrderBy(r=>r.PlaceId).ToList();
            List<PlaceViewModel> thisSessionPlaces = new List<PlaceViewModel>(); //информация о всех местах на выбранный сеанс
            foreach(var place in places)
            {
                Place placeInfo = db.Places.Where(p => p.Id == place.PlaceId).FirstOrDefault();
                PlaceViewModel curPlace = new PlaceViewModel
                {
                    Id =place.PlaceId,
                    Row = placeInfo.RowNumber,
                    PlaceNum = placeInfo.PlaceNumber,
                    Availability = place.Availability,
                    Cost = place.Cost
                };
                thisSessionPlaces.Add(curPlace);
            }
            thisSessionPlaces = thisSessionPlaces.OrderBy(p => p.Row).ThenBy(m => m.PlaceNum).ToList(); //отсортированная последовательность мест в зрительном зале
            int i = 0;
            HallSession hallForSession = new HallSession();
            while (i < thisSessionPlaces.Count)
            {
                RowPlaces curRow = new RowPlaces();
                curRow.Row = thisSessionPlaces[i].Row;
                curRow.Places.Add(thisSessionPlaces[i]);
                i++;
                while (i<thisSessionPlaces.Count && thisSessionPlaces[i].Row == thisSessionPlaces[i - 1].Row) //пока места принадлежат одному и тому же ряду 
                {
                    curRow.Places.Add(thisSessionPlaces[i]);
                    i++;
                }
                hallForSession.HallPlaces.Add(curRow); //добавление нового ряда в зал
            }
            //получен зал hallForSession
            string json = JsonSerializer.Serialize(hallForSession);
            return Json(hallForSession);
        }

        

    }
}
