// Minimal fetch-based HTTP helper. Replaces axios.
//
// Behaviour intentionally mirrors the parts of axios this project relied on:
//  - Non-2xx responses reject (so existing .catch blocks keep working, e.g.
//    the "out of stock" toast that fires on a 400 from /Cart/AddOne).
//  - Plain objects are sent as JSON; FormData is sent as-is (multipart).
//  - The resolved value is the parsed response body (JSON when the server
//    says so, otherwise text) - i.e. what axios exposed as `res.data`.
window.http = (function () {
    async function request(method, url, body) {
        const options = { method };

        if (body instanceof FormData) {
            options.body = body;
        } else if (body !== undefined && body !== null) {
            options.headers = { 'Content-Type': 'application/json' };
            options.body = JSON.stringify(body);
        }

        const response = await fetch(url, options);
        if (!response.ok) {
            throw new Error('Request failed with status ' + response.status);
        }

        const contentType = response.headers.get('content-type') || '';
        return contentType.includes('application/json')
            ? response.json()
            : response.text();
    }

    return {
        get: (url) => request('GET', url),
        post: (url, body) => request('POST', url, body),
        put: (url, body) => request('PUT', url, body),
        delete: (url) => request('DELETE', url),
    };
})();
