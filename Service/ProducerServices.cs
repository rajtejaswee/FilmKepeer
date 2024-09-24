using System;
using System.Collections.Generic;
using Filmkeeper.Entities;
using Filmkeeper.Exceptions;

public class ProducerServices : IProducerServices
{
    private readonly IProducerRepository _producerRepository;

    public ProducerServices(IProducerRepository producerRepository)
    {
        _producerRepository = producerRepository;
    }

    public List<Producers> Get()
    {
        return _producerRepository.Get();
    }

    public Producers Get(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }

        var producer = _producerRepository.Get(id);
        if (producer == null)
        {
            throw new InvalidArguementException($"Producer with ID {id} not found.");
        }

        return producer;
    }

    public void Update(Producers producer)
    {
        if (producer == null || producer.id <= 0)
        {
            throw new InvalidArguementException("Invalid producer details.");
        }

        _producerRepository.Update(producer);
    }

    public void Create(Producers producer)
    {
        if (producer == null || string.IsNullOrEmpty(producer.Name))
        {
            throw new InvalidArguementException("Invalid producer details. Name is required.");
        }

        _producerRepository.Create(producer);
    }

    public void Delete(int id)
    {
        if (id <= 0)
        {
            throw new InvalidArguementException("Invalid ID. ID must be greater than zero.");
        }

        _producerRepository.Delete(id);
    }
}
