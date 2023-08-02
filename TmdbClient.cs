using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp
{
    public class TmdbClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TmdbClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;


        }

        //the method below is a get request to the the "/todo"

        public async Task<MovieList> GetPopularMovies()
        {

            var client = _httpClientFactory.CreateClient("tmdb");
            var response = await client.GetAsync("/3/movie/popular");
            response.EnsureSuccessStatusCode();
            string jsonContent = await response.Content.ReadAsStringAsync();
            MovieList result = JsonConvert.DeserializeObject<MovieList>(jsonContent);
            return result;
        }
        public async Task<MovieList> GetNextPage(int nextpage)
        {

            var client = _httpClientFactory.CreateClient("tmdb");
            var response = await client.GetAsync($"/3/movie/popular?page={nextpage}");
            response.EnsureSuccessStatusCode();
            string jsonContent = await response.Content.ReadAsStringAsync();
            MovieList result = JsonConvert.DeserializeObject<MovieList>(jsonContent);
            return result;
        }

        public async Task<MovieList> SearchMovies(string searchQuery)
        {
            if(string.IsNullOrEmpty(searchQuery))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient("tmdb");
            var response = await client.GetAsync("/3/search/movie?query=" + searchQuery);

            string jsonContent = await response.Content.ReadAsStringAsync();
            MovieList movieList = JsonConvert.DeserializeObject<MovieList>(jsonContent);

            return movieList;
        }


    }

}