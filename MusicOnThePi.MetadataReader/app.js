const http = require('http');
const musicmetadata = require('musicmetadata');
const multer = require('multer');
const express = require('express');
const streamifier = require('streamifier');
const Promise = require('bluebird');
const fs = require('fs');
const path = require('path');

const app = express();
const storage = multer.memoryStorage();
const upload = multer({ storage });

app.get('/', function (req, res, next) {
    res.send('upload tracks to get metadata');
});

app.post('/', upload.array('tracks'), function (req, res, next) {
    const musicmetadataAsync = Promise.promisify(musicmetadata);

    Promise
        .all(req.files
            .map(file => musicmetadataAsync(streamifier.createReadStream(file.buffer))
            .then(meta => ({
                metadata: meta,
                fileName: file.originalname,
                mimeType: file.mimetype,
                ext: path.extname(file.originalname)
            })))
        )
        .then(metas => ({
            artist: metas[0].metadata.artist[0],
            album: metas[0].metadata.album,
            tracks: metas.map(meta => ({
                title: meta.metadata.title,
                fileName: meta.fileName,
                mimeType: meta.mimeType,
                ext: meta.ext
            }))
        }))
        .then(meta => res.json(meta))
        .catch(err => {
            res.status(500);
            res.json(err);
            console.log(err);
        });
});

app.listen(8000, function () {
    console.log('Example app listening on port 8000!');
});
