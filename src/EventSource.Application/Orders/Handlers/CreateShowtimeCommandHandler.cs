using EventSource.Application.Orders.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Showtime;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandComplete>
{
    private readonly ILogger<CreateOrderCommandHandler> _logger;


    public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task<CreateOrderCommandComplete> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<CreateShowtimeCommandComplete> Handle(CreateShowtimeCommand request, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        //_logger.LogDebug("Starting handling an event at '{CommandHandler}'", nameof(CreateShowtimeCommandHandler));

    //        ////Create Movie
    //        //var movie = MovieEntity.Create(request.Movie.Title, request.Movie.Stars, request.Movie.ImdbId, request.Movie.ReleaseDate);

    //        //var auditoriumDefinition = await _auditoriumRepository.GetAsync(request.AuditoriumId, cancellationToken)
    //        //                           ?? throw new InvalidOperationException("Auditorium not exit");

    //        //var showtime = ShowtimeEntity.Create(auditoriumDefinition, movie, request.SessionDate);

    //        //await _showtimesRepository.AddAsync(showtime);

    //        //await _showtimesRepository.SaveChangesAsync();

    //        //return new CreateShowtimeCommandComplete() { Id = showtime.Id };
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "An error occurred at {CommandHandler}", nameof(CreateShowtimeCommandHandler));
    //        throw;
    //    }
    //}


}