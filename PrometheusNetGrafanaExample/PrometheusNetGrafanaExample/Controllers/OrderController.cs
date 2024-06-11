using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace PrometheusNetGrafanaExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;

		private static readonly Histogram ProcessingTimeHistogram = Metrics.
			CreateHistogram("api_getorder_processingtime_histogram",
			"API - Get order processing time histogram in seconds.",
			new HistogramConfiguration
			{
				Buckets = Histogram.LinearBuckets(start: 1, width: 1, count: 3)
			});

		public OrderController(ILogger<OrderController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetMyOrders")]
		public string[] Get()
		{
			ProcessingTimeHistogram.Observe(0.5);

			ProcessingTimeHistogram.Observe(1.2);
			ProcessingTimeHistogram.Observe(1.6);


			ProcessingTimeHistogram.Observe(2.1);


			ProcessingTimeHistogram.Observe(5.3);
			ProcessingTimeHistogram.Observe(7.123);
			ProcessingTimeHistogram.Observe(10);

			var myOrders = new string[] { "Laptop", "Web camera" };
			return myOrders;
		}
	}
}
