﻿export function createSpotifyPlayer(accessToken) {
    return new Spotify.Player({
        name: 'CdR',
        getOAuthToken: cb => { cb(accessToken); },
        volume: 1
    });
}

export function setSpotifyPlayerListeners(spotifyPlayer) {
    spotifyPlayer.addListener('not_ready', ({ device_id }) => {
        console.log('Você saiu do Spotify', device_id);
    });

    spotifyPlayer.addListener('initialization_error', ({ message }) => {
        console.error(message);
    });

    spotifyPlayer.addListener('authentication_error', ({ message }) => {
        console.error(message);
    });

    spotifyPlayer.addListener('account_error', ({ message }) => {
        console.error(message);
    });

    spotifyPlayer.addListener('player_state_changed', (state => {
        if (!state) {
            return;
        }
        
        DotNet.invokeMethodAsync('Clube', 'SpotifyStateHasChanged', state)
            .then(success => {
                if (!success) {
                    console.warn("Falha ao atualizar status do Spotify!");
                }
            });
    }));
}

export function getCurrentStateSpotifyPlayer(spotifyPlayer) {
    spotifyPlayer.getCurrentState().then(state => {
        DotNet.invokeMethodAsync('Clube', 'SpotifyStateHasChanged', state)
            .then(success => {
                if (!success) {
                    console.warn("Falha ao atualizar status do Spotify!");
                }
            });
    });
}

export function connectSpotifyPlayer(spotifyPlayer) {
    spotifyPlayer.connect().then(success => {
        if (success) {
            console.log('Você está conectado ao Spotify!');
        }
    });
}

export function disconnectSpotifyPlayer(spotifyPlayer) {
    spotifyPlayer.disconnect().then(success => {
        if (success) {
            console.log('Você desconectou do player do Spotify.');
        }
    });
}

export function play(spotifyPlayer) {
    spotifyPlayer.togglePlay();
}