﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Papiezak
{
    internal class midi
    {
        byte[] midiBytes;
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command, string buffer, int bufferSize, IntPtr hwndCallback);
        StringBuilder errorText = new StringBuilder(256);

        string tempMidiFile = "Barka_karaoke.mid"; // Adjust the namespace and filename

        public void isFileThere() 
        {
            if (!File.Exists(tempMidiFile)) 
            {
                string midiFileBase64 = "TVRoZAAAAAYAAAABAeBNVHJrAAAdiQD/AxZCYXJrYS1QaWWc8SBPYXpvd2EoUEwpAP8CQUNvcHlyaWdodCCpIGJ5IE1JREktTkVUIHMuYy4sIFdzemVsa2llIHByYXdhIHphc3RyemV6b25lISEhIDIwMDUgAP8BPlRlbiBwbGlrIE1JREkgem9zdGFsIG5hcGlzYW55IHByemV6IG11enlrb3cgZmlybXkgTUlESS1ORVQhISEKAP8BIEtvcGlvd2FuaWUgc3Vyb3dvIHphYnJvbmlvbmUhISEKAP8BDk1JREktTkVUIHMuYy4KAP8BD3VsLiBNb3N0b3dhIDMwCgD/AQ42MS04NTQgUG96bmFuCgD/ARduci4gdGVsLiAwNjEgOCA1MjYgNTI2CgD/ARh0ZWwuIGtvbS4gMCA1MDQgODA4IDQyMgoA/wEPd3d3LnV0d29ya2kucGwKAP8BLisrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKwoA/1gEDAMMCAD/WQIAAAD/UQMKxVoA/wZBQ29weXJpZ2h0IKkgYnkgTUlESS1ORVQgcy5jLiwgV3N6ZWxraWUgcHJhd2EgemFzdHJ6ZXpvbmUhISEgMjAwNSAAsAAAAAdBAApkAFtGAF0jALEAAAAHZAAKQABbCgBdAACyAAAABzwAChQAW0YAXSMAswAAAAd4AApAAFtGAF0jALQAAAAHeAAKbgBbRgBdNwC1AAAAB2QACloAW0YAXSUAtgAAAAc8AAogAFtuAF0UALcAAAAHWgAKQABbRgBdNwC4AAAAB0sAClQAW0YAXSMAuQAAAAdkAApAAFtGAF0AALoAAAAHUAAKIgBbRgBdIwC7AAAAB1AAClQAW0YAXSMAvAAAAAdfAApaAFtGAF0jAL0AAAAHUAAKDABbZABdHgAgAAC5IAAAvCAAALEgAAC7IAAAsiAAALogAAC3IAAAtiAAALUgAAC4IAAAsyAAALAgAAC0IAABzSgAzBkAyzEAyjQAyQAAyGQAxxEAxi4AxRsAxBMAwxUAwjEAwSMAwBIAsAEAAAt/ALEBAAALfwCyAQAAC24AswEAAAt/ALQBAAALfwC1AQAAC38AtgEAAAt/ALcBAAALfwC4AQAAC38AuQEAAAt/ALoBAAALfwC7AQAAC38AvAEAAAt/AL0BAAALf3eTNAEA/wUCKiAA/wUBDQGTNACKJzQBAP8FBkJBUktBIAD/BQENAZM0AIc/NAEA/wUEKioqIAD/BQENAZM0AINfkEV/AEp/AE5/AJEmfwCSRX8ASn8ATn8AkzQBAJRCfwCXSm4AmSR/ACpkADFkAJw+bgCdQn8A/wUGUGllnPEgAZM0AGOXSgAAmSoAZiQAJJw+AAKXTm4AmSpkAJxCbmSZKgAAl04AOb0BQE2ZMQAEnEIAApdRbgCZKmQAnEVuZJkqAACXUQASlEIAeJxFAAKUQn8AlTlkAD5kAEJkAJdWbgCZJnMAKmQANloAnEpuZJk2AAAqAAAmAACXVgCBCpxKAACRJgACl1FuAJkqZACcRW5kmSoAAJdRABKVOQAAPgAAQgB4nEUAApEmfwCXTm4AmSR/ACpkAJxCbmSZKgAAl04AAJkkAGaRJgAUvQFkEJJOAABFAACQRQAAlEIAAJxCAACQSgAAkkoAAJBOAAJFfwBJfwBMfwCRIX8AkkV/AEl/AEx/AJM0AQCXRW4AmSR/ACpkAJw5bgD/BQdPYXpvd2EgAP8FAQ0BkzQAY5kkAACXRQAAmSoASL0BAEKdQgAAnDkAApRAfwCXSW4AmSpkAJw9bgCdQH9kmSoAAJdJABKUQAB4nD0AAJ1AAAKUQn8Al0xuAJkqZACcQG4AnUJ/ZJkqAACXTAASlEIAeJxAAACdQgAClEN/AJU5ZAA9ZABAZACXUW4AmSZzACpkADZaAJxFbgCdQ39kmTYAACoAACYAAJdRABKUQwB4nUMAAJxFAACRIQACkzQBAJRCfwCXTG4AmSpkAJxAbgCdQn8A/wUMKysrKysrKysrKysgAP8FAQ0BkzQAY5kqAACXTAASlEIAAJU9AABAAAA5AHicQAAAnUIAApRAfwCXSW4AmSpkAJw9bgCdQH9kmSoAAJdJABKUQAB4kkUAAJBFAABMAACSTAAAnUAAAJw9AACQSQAAkkkAApBFfwBKfwBOfwCRJn8AkkV/AEp/AE5/AJM0AQCUPn8Al0puAJkkfwAqZACcPm4AnT5/AP8FD3d3dy51dHdvcmtpLnBsIAD/BQENAZM0AGOXSgAAmSoAZiQAJJw+AAKXTm4AmSpkAJxCbie9AUA9mSoAAJdOAIEKnEIAApdRbgCZKmQAnEVuZJkqAACXUQASlD4AeJxFAAKUPn8AlTlkAD5kAEJkAJdWbgCZJnMAKmQANloAnEpuZJk2AAAqAAAmAACXVgCBCpxKAACRJgACkzQBAJdRbgCZKmQAnEVuAP8FFHNhZG93c2t5QHV0d29ya2kucGwgAP8FAQ0BkzQAY5kqAACXUQASlTkAAD4AAEIAeJxFAAKRIX8Al05uAJkkfwAqZACcQm5kmSoAAJdOAACZJAAEvQFkVwEAC5EhACSSTgAAnT4AAJJFAACUPgAAnEIAAJJKAACQRQAASgAATgACkSZ/AJM0AQCXSm4AmSR/ADFkAJw+bgD/BR0qKioqKioqKioqKioqKioqKioqKioqKioqKioqIAD/BQENAP8FAQoBkzQAY5kxAAAkAACXSgCBCpEmAACcPgCDYpEhfwCVOWQAPmQAQmQAmSZzADZaZDYAACYAgQqRIQACI38AmS9udpU5AABCAAA+AAeZLwBxkSMAAiV/AJkrbmYrAIEIkSUAApBFfwBKfwBOfwCRJn8AkkV/AEp/AE5/AJNCfwCXSm4AmE5kAJkkfwA5ZACaQmQAm0JkAJw+bgD/BQRQYW4gZJk5AACXSgBmmSQAJJw+AAKXTm4AmSxkAJxCbmSZLAAAl04AgQqcQgACl1FuAJksZACcRW5kmSwAAJdRAIEKnEUAApU5ZAA+ZABCZACXVm4AmSZzACxkAJxKbmSZLAAAJgAAl1YAgQqcSgAAkSYAApdRbgCZLGQAnEVuZJksAACXUQASlTkAAD4AAEIAeJxFAAKRJn8Al05uAJkkfwAsZACcQm5kmSwAACQAAJdOAGaRJgAkmE4AAJBOAABFAACSRQAAkEoAAJxCAACSSgAATgACkEV/AEl/AEx/AJEhfwCSRX8ASX8ATH8Al0VuAJkkfwAsZACcOW5kmSwAACQAAJdFAIEKm0IAAJNCAACaQgAAnDkAApNAfwCXSW4AmSxkAJpAZACbQGQAnD1uAP8FA2tpZWSZLAAAl0kAZppAAACTQAAAm0AAJJw9AAKTQn8Al0xuAJksZACaQmQAm0JkAJxAbgD/BQRkeZwgZJksAACXTABmmkIAAJNCAACbQgAknEAAApNDfwCVOWQAPWQAQGQAl1FuAJhMZACZJnMALGQAmkNkAJtDZACcRW4A/wUDc3RhZJksAAAmAACXUQBmm0MAAJpDAACTQwAkkSEAAJxFAAKTQn8Al0xuAJksZACaQmQAm0JkAJxAbgD/BQRuubMgZJksAACXTAASlT0AAEAAADkAVJpCAACTQgAAm0IAJJxAAAKTQH8Al0luAJksZACaQGQAm0BkAJw9bgD/BQRuYWQgZJksAACXSQBmmkAAAJNAAACbQAAkkEUAAJJFAABMAACcPQAAkEkAAJJJAACYTAAAkEwAAkd/AEp/AE5/AJEjfwCSR38ASn8ATn8Akz5/AJdHbgCYSmQAmSR/ACxkAJo+ZACbPmQAnDtuAP8FBGJyemVkmSwAAJdHAGaZJAAknDsAApdKbgCZLGQAnD5uZJksAACXSgCBCpw+AAKXTm4AmSxkAJxCbmSZLAAAl04AEpo+AACTPgAAmz4AeJxCAAKTPn8AlTtkAD5kAEJkAJdTbgCZJnMALGQAmj5kAJs+ZACcR24A/wUGZ2llbSwgAP8FAQ1kmSwAACYAAJdTAIEKnEcAAJEjAAKXTm4AmSxkAJxCbmSZLAAAl04AEpU7AAA+AABCAHicQgACkSN/AJdKbgCZJH8ALGQAnD5uZJksAAAkAACXSgBmkSMAJJhKAACcPgACkR5/AJdHbgCZJH8ALGQAnDtuZJksAAAkAACXRwCBCpw7AAKXSm4AmSxkAJw+bmSZLAAAl0oAgQqcPgACl05uAJksZACcQm5kmSwAAJdOAIEKmz4AAJo+AACTPgAAnEIAApNAfwCVO2QAPmQAQmQAl1NuAJhPZACZJnMALGQAmkBkAJtAZACcR24A/wUDU3p1ZJksAAAmAACXUwCBCpxHAACRHgACl05uAJksZACcQm5kmSwAAJdOABKVPgAAOwAAQgAwmkAAAJtAAACTQABInEIAAJhPAAKTQn8Al0puAJhOZACZLGQAmkJkAJtCZACcPm4A/wUEa2GzIGSZLAAAl0oAZppCAACTQgAAm0IAJJBHAABOAACSRwAAnD4AAJJKAACYTgAAkEoAAJJOAAKQR38ASn8AT38AkR9/AJJHfwBKfwBPfwCTQ38Al0NuAJhPZACZJH8ALGQAmkNkAJtDZACcN24A/wUCbHVkmSwAAJdDAGaZJAAknDcAApdHbgCZLGQAnDtuZJksAACXRwCBCpw7AAKXSm4AmSxkAJw+bmSZLAAAl0oAEppDAACTQwAAm0MAeJw+AAKTQ38AlTtkAD5kAENkAJdPbgCZJnMALGQAmkNkAJtDZACcQ24A/wUEZHppIAD/BQENZJksAAAmAACXTwCBCpxDAACYTwAAkR8AApdKbgCZLGQAnD5uZJksAACXSgASlTsAAEMAAD4AeJw+AAKRHn8Al0duAJkkfwAsZACcO25kmSwAACQAAJdHAGaRHgAknDsAApEcfwCXQ24AmFNkAJkkfwAsZACcN25kmSwAACQAAJdDAIEKnDcAApdHbgCZLGQAnDtuZJksAACXRwCBCpNDAACbQwAAmkMAAJw7AAKTQ38Al0puAJksZACaQ2QAm0NkAJw+bgD/BQJHb2SZLAAAl0oAZpNDAACbQwAAmkMAJJhTAACcPgACk0N/AJU7ZAA+ZABDZACXT24AmFFkAJkmcwAsZACaQ2QAm0NkAJxDbgD/BQJ0b2SZLAAAJgAAl08AZptDAACaQwAAk0MAJJEcAACcQwACk0N/AJdKbgCZLGQAmkNkAJtDZACcPm4A/wUFd3ljaCBkmSwAAJdKABKVPgAAQwAAOwBUmkMAAJNDAACbQwAknD4AAJhRAAKTQn8Al0duAJhOZACZLGQAmkJkAJtCZACcO24A/wUGcPNqnOYgZJksAACXRwBmmkIAAJNCAACbQgAkkEcAAE8AAJJKAACcOwAAkkcAAJhOAACSTwAAkEoAAkV/AEl/AEx/AJEhfwCSRX8ASX8ATH8Ak0B/AJdFbgCYTGQAmSR/ACxkAJpAZACbQGQAnDluAP8FA3phIGSZLAAAl0UAZpkkACScOQACl0luAJksZACcPW5kmSwAAJdJAIEKnD0AApdMbgCZLGQAnEBuZJksAACXTAASmkAAAJNAAACbQAB4nEAAApNAfwCVOWQAPWQAQGQAl1FuAJkmcwAsZACaQGQAm0BkAJxFbgD/BQROaW0gAP8FAQ1kmSwAACYAAJdRAIEKnEUAAJEhAAKXTG4AmSxkAJxAbmSZLAAAl0wAEpU5AAA9AABAAHicQAAAmEwAApEhfwCXSW4AmEpkAJkkfwAsZACcPW5kmSwAACQAAJdJAGaRIQAkmEoAAJw9AAKRHH8Al0VuAJhJZACZJH8ALGQAnDluZJksAAAkAACXRQCBCpw5AAKXSW4AmSxkAJw9bmSZLAAAl0kAgQqbQAAAmkAAAJNAAACcPQACkzl/AJdMbgCZLGQAmjlkAJs5ZACcQG4A/wUDQnkgZJksAACXTABmkzkAAJs5AACaOQAknEAAApM+fwCVOWQAPWQAQGQAl1FuAJkmcwAsZACaPmQAmz5kAJxFbgD/BQKzb2SZLAAAJgAAl1EAgQqcRQACl0xuAJkmcwAsZACcQG5kmSwAAJdMABKRHAAAlTkAAD0AAEAAMJo+AACbPgAAkz4AJJkmACScQAACk0B/AJdJbgCZJnMALGQAmkBkAJtAZACcPW4A/wUEd2nmIGSZLAAAl0kAZpkmAACTQAAAm0AAAJpAACSSTAAASQAAnD0AAJBFAABMAABJAACYSQAAkkUAApBFfwBKfwBOfwCRJn8AkkV/AEp/AE5/AJNCfwCXSm4AmE5kAJkkfwAsZAAxZACaQmQAm0JkAJw+bgD/BQJzZR6ZMQBGLAAAl0oAZpkkACScPgACl05uAJksZACcQm5kmSwAAJdOAIEKnEIAApdRbgCZLGQAnEVuZJksAACXUQCBCpNCAACbQgAAmkIAAJxFAAKTQn8AlTlkAD5kAEJkAJdWbgCZJnMALGQAmkJkAJtCZACcSm4A/wUEcmNhIAD/BQENZJksAAAmAACXVgCBCpxKAACRJgACl1FuAJksZACcRW5kmSwAAJdRABKVOQAAPgAAQgB4nEUAApEmfwCXTm4AmSR/ACxkAJxCbmSZLAAAJAAAl04AZpEmACSQRQAAkk4AAEUAAJBKAACSSgAAnEIAAJhOAACQTgACRX8ASX8ATH8AkSF/AJJFfwBJfwBMfwCXRW4AmSR/ACxkAJw5bmSZLAAAJAAAl0UAgQqcOQACl0luAJhMZACZLGQAnD1uZJksAACXSQCBCptCAACaQgAAk0IAAJw9AAKTQH8Al0xuAJksZACaQGQAm0BkAJxAbgD/BQVTs/N3IGSZLAAAl0wAZpNAAACbQAAAmkAAJJxAAAKTQn8AlTlkAD1kAEBkAJdRbgCZJnMALGQAmkJkAJtCZACcRW4A/wUCQm9kmSwAACYAAJdRAIEKnEUAAJEhAAKXTG4AmSxkAJxAbmSZLAAAl0wAEpU5AAA9AABAADCaQgAAm0IAAJNCAEicQAAAmEwAApNAfwCXSW4AmExkAJksZACaQGQAm0BkAJw9bgD/BQW/eWNoIGSZLAAAl0kAZppAAACTQAAAm0AAJJBFAACSRQAAkEkAAJw9AACSSQAAmEwAAJJMAACQTAACRX8ASn8ATn8AkSZ/AJJFfwBKfwBOfwCTPn8Al0puAJhKZACZJH8ALGQAmj5kAJs+ZACcPm4A/wUDcHJhZJksAACXSgBmmSQAJJw+AAKXTm4AmSxkAJxCbmSZLAAAl04AgQqcQgACl1FuAJksZACcRW5kmSwAAJdRAIEKkz4AAJs+AACaPgAAnEUAApM+fwCVOWQAPmQAQmQAl1ZuAJkmcwAsZACaPmQAmz5kAJxKbgD/BQV3ZLkuIAD/BQENAP8FAQpkmSwAACYAAJdWAIEKnEoAApdRbgCZLGQAnEVuZJksAACXUQASkSYAAJVCAAA5AAA+AHicRQACkSF/AJdObgCZJH8ALGQAnEJuZJksAAAkAACXTgBmkSEAJJBFAACSRQAAmEoAAJxCAAKQSH8AkSR/AJJIfwCXSm4AmFRkAJkkfwAmcwAsZAAybgA5ZACcPm4nmTkAPTIAACwAACYAACQAAJdKAGaRJAAknD4AApEmfwCXTm4AmSxkADJuAJxCbmSZMgAALAAAl04AZpEmACSbPgAAmj4AAJM+AACcQgACkSR/AJdRbgCZLGQAMm4AnEVuZJkyAAAsAACXUQAUmSZzUpEkABKZJgASnEUAApEhfwCTPn8AlTxkAD5kAEJkAJYyfwCXVG4AmSZzACxkADBuAJo+ZACbPmQAnEhuAP8FAk8gHpY2fx45fx42fwqZMAAALAAAJgAAl1QAFJY5fwCZMG4elj5/Hjl/FpEhAAiWPn8KmTAAEpxIAACWMgACkSR/AJZCfwCXUW4AmSZzACxkADBuAJxFbhyWNgACPn8cOQACQn8cNgACRX8Kl1EAAJkwAAAsAAAmABKVPgAAPAAAljkAAJVCAAKWQn8AmTBuHJY+AAJFfxw5AAJKfxaRJAAGlj4AAkV/CpkwABKcRQAAlkIAApEmfwCWSn8Al05uAJksZAAwbgCcQm4clj4AAk5/HEIAAkp/HEUAAk5/CpkwAACXTgAAmSwAEpZCAAJRfwCZMG4clkUAAk5/HEoAAlF/FpEmAAaWRQAMmTAAEpZKAACQSgAAmFQAAJJOAACTPgAAkkoAAJBIAACbPgAAmj4AAJxCAACSSAAAkE4AAkd/AEp/AE9/AJEffwCSR38ASn8AT38Ak0d/AJZTfwCXQ24AmFNkAJkkfwAqZAA5ZACaR2QAm0dkAJw3bgD/BQJQYRyWTgAeSgAeTgAMmSoAAJdDABKWUQAeTgAeUQAYmSQAJJw3AACWUwACl0duAJkqZACcO25kmSoAAJdHAIEKnDsAApdKbgCZKmQAnD5uZJkqAACXSgCBCphTAACaRwAAm0cAAJNHAACcPgACk0d/AJU7ZAA+ZABDZACXT24AmEpkAJkmcwAqZAA2WgCaR2QAm0dkAJxDbgD/BQVuaWUsIAD/BQENZJk2AAAqAAAmAACXTwCBCpxDAACRHwACl0puAJkqZACcPm5kmSoAAJdKABKVOwAAPgAAQwB4nD4AAJk5AAKRK38Al0duAJkkfwAqZACcO25kmSoAACQAAJdHAGaRKwAknDsAApEffwCXQ24AmSR/ACpkAJw3bmSZKgAAJAAAl0MAgQqTRwAAm0cAAJpHAACcNwACk0d/AJdHbgCZKmQAmkdkAJtHZACcO24A/wUDVG8gZJkqAACXRwBmk0cAAJtHAACaRwAknDsAApNJfwCXSm4AmSpkAJpJZACbSWQAnD5uAP8FA1R5IGSZKgAAl0oAZpNJAACbSQAAmkkAJJhKAACcPgACk0p/AJU7ZAA+ZABDZACXT24AmFFkAJkmcwAqZAA2WgCaSmQAm0pkAJxDbgD/BQNuYSBkmTYAACoAACYAAJdPAGabSgAAmkoAAJNKACSRHwAAnEMAApNJfwCXSm4AmSpkAJpJZACbSWQAnD5uAP8FBW1uaWUgZJkqAACXSgASlT4AAEMAADsAVJpJAACTSQAAm0kAJJw+AACYUQACkR9/AJNHfwCXR24AmE9kAJkqZACaR2QAm0dkAJw7bgD/BQRzcG9qZJkqAACXRwBmkR8AAJNHAACbRwAAmkcAJJBPAABKAACcOwAAmE8AAJJKAACQRwAAkkcAAE8AApBFfwBKfwBOfwCRJn8AkkV/AEp/AE5/AJNFfwCXPm4AmE9kAJkkfwAqZACaRWQAm0VkAJwybgD/BQNyemFkmSoAAJc+AGaZJAAknDIAApdCbgCZKmQAnDZuZJkqAACXQgCBCpw2AAKXRW4AmSpkAJw5bmSZKgAAl0UAgQqaRQAAmE8AAJtFAACTRQAAnDkAApNFfwCVOWQAPmQAQmQAl0puAJhOZACZJnMAKmQANloAmkVkAJtFZACcPm4A/wUFs2WcLCAA/wUBDWSZNgAAKgAAJgAAl0oAgQqcPgACl0VuAJkqZACcOW5kmSoAAJdFABKVOQAAkSYAAJU+AABCAHicOQACkSR/AJdCbgCZJH8AKmQAnDZuZJkqAAAkAACXQgBmkSQAJJJFAACQRQAAmE4AAJw2AAKQR38AkSN/AJJHfwCXPm4AmSR/ACpkAJwybmSZKgAAJAAAlz4AgQqcMgACl0JuAJkqZACcNm5kmSoAAJdCAIEKk0UAAJpFAACbRQAAnDYAApdFbgCZKmQAnDluZJkqAACXRQCBCpw5AAKTQ38AlTtkAD5kAEJkAJdHbgCZJnMAKmQANloAmkNkAJtDZACcO24A/wUDVHdvZJk2AAAqAAAmAACXRwCBCpw7AACRIwACl0VuAJhOZACZKmQAnDluZJkqAACXRQASlT4AADsAAEIAeJw5AACaQwAAm0MAAJNDAACYTgACk0J/AJdCbgCYTmQAmSpkAJpCZACbQmQAnDZuAP8FA2plIGSZKgAAl0IAZppCAACTQgAAm0IAJJBKAABHAACSTgAAnDYAAJJKAACYTgAAkkcAAJBOAAD/LwA=";
                byte[] midiBytes = Convert.FromBase64String(midiFileBase64);
                string tempFilePath = "Barka_karaoke.mid";
                System.IO.File.WriteAllBytes(tempFilePath, midiBytes);
            }
        }
        public midi() 
        {
            isFileThere();
            string command = $"open \"{tempMidiFile}\" type sequencer alias myMidi";
            mciSendString(command, null, 0, IntPtr.Zero);


            // Set starting point to 3 seconds (3000 milliseconds) into the MIDI
            command = "seek myMidi to 4000";
            mciSendString(command, null, 0, IntPtr.Zero);
            // Play the MIDI file in a loop
            command = "play myMidi";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void play() 
        {
            string command = $"open \"{tempMidiFile}\" type sequencer alias myMidi";
            mciSendString(command, null, 0, IntPtr.Zero);


            // Set starting point to 3 seconds (3000 milliseconds) into the MIDI
            command = "seek myMidi to 4000";
            mciSendString(command, null, 0, IntPtr.Zero);
            // Play the MIDI file in a loop
            command = "play myMidi";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}