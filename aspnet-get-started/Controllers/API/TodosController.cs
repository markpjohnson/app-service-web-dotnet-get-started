using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using aspnet_get_started.Models;
using Microsoft.Azure.Documents.Client;

namespace aspnet_get_started.Controllers.API
{
	[RoutePrefix("api/todos")]
	public class TodosController : ApiController
	{
		public const string Database = "TodoDb";
		public const string Collection = "Todo";

		private readonly DocumentClient client;

		public TodosController()
		{
			this.client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["DocumentDbUri"]), ConfigurationManager.AppSettings["DocumentDbKey"]);
		}

		// GET api/<controller>
		[Route]
		[HttpGet]
		public IEnumerable<Todo> Get()
		{
			return this.client.CreateDocumentQuery<Todo>(UriFactory.CreateDocumentCollectionUri(TodosController.Database, TodosController.Collection),
														new FeedOptions
														{
															MaxItemCount = -1
														});
		}

		// GET api/<controller>/5
		[Route("{id}")]
		[HttpGet]
		public Todo Get(string id)
		{
			return this.client.CreateDocumentQuery<Todo>(UriFactory.CreateDocumentCollectionUri(TodosController.Database, TodosController.Collection),
														new FeedOptions
														{
															MaxItemCount = 1
														}).SingleOrDefault(t => t.Id == id);
		}

		// POST api/<controller>
		[Route]
		[HttpPost]
		public async Task<IEnumerable<Todo>> Post([FromBody] Todo todo)
		{
			await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(TodosController.Database, TodosController.Collection),
												new Todo
												{
													Text = todo.Text,
													Created = DateTime.Now
												});
			return this.Get();
		}

		// DELETE api/<controller>/5
		[Route("{id}")]
		[HttpDelete]
		public async Task<IEnumerable<Todo>> Delete(string id)
		{
			await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(TodosController.Database, TodosController.Collection, id));
			return this.Get();
		}
	}
}