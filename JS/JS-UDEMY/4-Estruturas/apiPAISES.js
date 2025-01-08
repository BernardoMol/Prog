const http = require('https');

const options = {
	method: 'GET',
	hostname: 'countries-states-and-cities.p.rapidapi.com',
	port: null,
	path: '/states?country=CL',
	headers: {
		'X-RapidAPI-Key': 'be1d417e99mshd13b1b1347babe1p1bd1bdjsnbab6645f697d',
		'X-RapidAPI-Host': 'countries-states-and-cities.p.rapidapi.com'
	}
};

const req = http.request(options, function (res) {
	const chunks = [];

	res.on('data', function (chunk) {
		chunks.push(chunk);
	});

	res.on('end', function () {
		const body = Buffer.concat(chunks);
		console.log(body.toString());
	});
});

req.end();