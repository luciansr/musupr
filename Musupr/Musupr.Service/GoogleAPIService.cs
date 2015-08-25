using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps.DistanceMatrix;
using Google.Maps;

/*
 *    Google Maps:
 *    https://developers.google.com/maps/documentation/distancematrix/ 
 *    Directions
 * 
 *    http://maps.googleapis.com/maps/api/directions/json?origin=Dias+Leme+569+Mesquita&destination=Barra+Tijuca+Rio+Janeiro&sensor=false 
 *    http://maps.googleapis.com/maps/api/directions/json?origin=lat,long&destination=lat,long&sensor=false 
 * 
 *    Distance matrix
 *    http://maps.googleapis.com/maps/api/distancematrix/json?origins=rua+dias+leme+rocha+sobrinho&destinations=barra+tijuca+rio+janeiro&sensor=false 
 * 
 * 
 *    http://maps.googleapis.com/maps/api/distancematrix/json?origins=-22.7769,-43.3998&destinations=barra+tijuca+rio+janeiro&sensor=false 
 * 
 *    Geolocation= endereço a partir de lat long
 *    http://maps.googleapis.com/maps/api/geocode/json?address=-22.7769,-43.3998&sensor=false 
 * 
 */

namespace Musupr.Service
{
    public class GoogleAPIService
    {
        public double CalculaDistanciaEntreDoisPontos(double lat1, double long1, double lat2, double long2)
        {
            DistanceMatrixRequest request = new DistanceMatrixRequest();
            request.AddOrigin(new Waypoint { Position = new LatLng(lat1, long1) });
            request.AddDestination(new Waypoint { Position = new LatLng(lat2, long2) });
            request.Sensor = false;

            try
            {
                DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

                if (response.Status == ServiceResponseStatus.Ok)
                {
                    int distInteger;

                    if (Int32.TryParse(response.Rows[0].Elements[0].distance.Value, out distInteger))
                    {
                        return (double)distInteger / 1000;
                    }
                }
            }
            catch { }

            return 0.0;
        }
    }
}
