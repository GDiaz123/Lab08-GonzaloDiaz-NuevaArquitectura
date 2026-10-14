using System;
using System.Collections.Generic;
using Lab08_GonzaloDiaz.DTOs;
using Lab08_GonzaloDiaz.Models;
namespace Lab08_GonzaloDiaz.Features.Order;

public interface IOrderServices
{
    List<Models.Order> ObtenerDespuesDeFecha(DateTime fecha);

    List<OrderWithDetailsDto> ObtenerPedidosConDetalles();
}