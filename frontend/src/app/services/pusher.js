const app_id = '626201';
const key = '9336e0704072cd38e1db';
const secret = '8d7468d1ea158dc400b1';
const cluster = 'eu';


Pusher.logToConsole = true;

export default new Pusher(key, {
    cluster: 'eu',
    forceTLS: true
});
