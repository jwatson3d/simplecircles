// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PeopleController.cs" company="John Watson">
// Copyright 2012 John Watson, New Hampshire, USA
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Circles.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    using AutoMapper;

    using Circles.Persistence;

    using Person = Circles.Models.Person;

    /// <summary>
    /// Controller for Person model
    /// </summary>
    public class PeopleController : Controller
    {
        private readonly IPartyRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleController"/> class.
        /// </summary>
        /// <param name="repository">
        /// Concrete implementation of the <see cref="IPartyRepository"/> interface to use.
        /// </param>
        public PeopleController(IPartyRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /People/
        public ViewResult Index()
        {
            var modelPersons = Mapper.Map<IEnumerable<Domain.Person>, IEnumerable<Person>>(this.repository.FindAllPersons());
            return View("Index", modelPersons);
        }

        //
        // GET: /People/Details/5
        public ViewResult Details(Guid id)
        {
            var person = Mapper.Map<Domain.Person, Person>(this.repository.FindById(id) as Domain.Person);
            return View("Details", person);
        }

        //
        // GET: /People/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /People/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", person);
            }

            var entity = Mapper.Map<Person, Domain.Person>(person);

            this.repository.Add(entity);

            TempData["message"] = string.Format("{0} was added", entity.PartyName);

            return RedirectToAction("Index");
        }

        //
        // GET: /People/Edit/5
        public ActionResult Edit(Guid id)
        {
            var person = Mapper.Map<Domain.Person, Person>(this.repository.FindById(id) as Domain.Person);

            return View("Edit", person);
        }

        //
        // POST: /People/Edit/5
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", person);
            }

            var entity = this.repository.FindById(person.PersonId) as Domain.Person;
            entity = Mapper.Map<Person, Domain.Person>(person);
            this.repository.Update(entity);

                TempData["message"] = string.Format("{0} was saved", entity.PartyName);
            return RedirectToAction("Index");
        }

        //
        // GET: /People/Delete/5
        public ActionResult Delete(Guid id)
        {
            var person = Mapper.Map<Domain.Person, Person>(this.repository.FindById(id) as Domain.Person);

            return View("Delete", person);
        }

        //
        // POST: /People/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.repository.Delete(id);

            TempData["message"] = string.Format("Person with unique identifier {0} deleted.", id);
            return RedirectToAction("Index");
        }
    }
}