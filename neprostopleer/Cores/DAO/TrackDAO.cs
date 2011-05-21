using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using neprostopleer.Entities.DB;
using System.Data.SQLite;
using neprostopleer.Util;

namespace neprostopleer.Cores.DAO
{
    class TrackDAO : IDAO
    {

#pragma region Mass methods
        public IList<Track> getTracksById(IList<string> ids)
        {
            IList<Track> outList = new List<Track>();
            foreach (string id in ids)
            {
                outList.Add(getTrackById(id));
            }
            return outList;
        }

        public IList<bool> updateTracks(IList<Track> tracks)
        {
            IList<bool> outList = new List<bool>();
            foreach (Track track in tracks)
            {
                outList.Add(updateTrack(track));
            }
            return outList;
        }

        public IList<bool> deleteTracks(IList<Track> tracks)
        {
            IList<bool> outList = new List<bool>();
            foreach (Track track in tracks)
            {
                outList.Add(deleteTrack(track));
            }
            return outList;
        }
        public IList<bool> deleteTracks(IList<string> ids)
        {
            IList<bool> outList = new List<bool>();
            foreach (string id in ids)
            {
                outList.Add(deleteTrack(id));
            }
            return outList;
        }
#pragma endregion Mass methods

        public Track getTrackById(string id)
        {
            Track t = null;
            using (SQLiteCommand fetchcommand = Program.storage.GetCommand("SELECT ID, STATE, DISKLOCATION, FETCHTIME FROM TRACKS WHERE ID=:id"))
            {
                fetchcommand.Parameters.AddWithValue("id", id);
                using (SQLiteDataReader reader = fetchcommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Behavior.Assert(true, "Should contain only single record in data base for track id " + id);
                        DateTime data_fetchtime = DateTime.FromBinary(reader.GetInt64(reader.GetOrdinal("FETCHTIME")));
                        string data_id = reader.GetString(reader.GetOrdinal("ID"));
                        string data_state = reader.GetString(reader.GetOrdinal("STATE"));
                        string data_disklocation = reader.GetString(reader.GetOrdinal("DISKLOCATION"));
                        t = new Track(data_id, data_state, data_disklocation, data_fetchtime);
                    }
                }
            }
            return t;
        }

        public bool updateTrack(Track track)
        {
            if (getTrackById(track.id) == null)
            {
                using (SQLiteCommand insertcommand = Program.storage.GetCommand("INSERT OR REPLACE INTO TRACKS( ID, STATE, DISKLOCATION, FETCHTIME) VALUES(:id, :state, :disklocation, :fetchtime)"))
                {
                    insertcommand.Parameters.AddWithValue("id", track.id);
                    insertcommand.Parameters.AddWithValue("state", track.state);
                    insertcommand.Parameters.AddWithValue("disklocation", track.disklocation);
                    insertcommand.Parameters.AddWithValue("fetchtime", track.fetchtime.Ticks/1000);
                    insertcommand.ExecuteNonQuery();
                }
                return false;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (track.id != null)
                    sb.Append(" ID = '").Append(track.id).Append("'");
                if (track.state != null)
                    if (sb.Length != 0) sb.Append(" , ");
                    sb.Append(" STATE = '").Append(track.state).Append("'");
                if (track.id != null)
                    if (sb.Length != 0) sb.Append(" , ");
                    sb.Append(" DISKLOCATION = '").Append(track.disklocation).Append("'");
                if (track.id != null)
                    if (sb.Length != 0) sb.Append(" , ");
                    sb.Append(" FETCHTIME = '").Append(track.fetchtime.Ticks / 1000).Append("'");
                if (sb.Length == 0)
                    throw new Exception("Cannot execute update when track object is fully nulled");
                using (SQLiteCommand updatecommand = Program.storage.GetCommand("UPDATE OR REPLACE TRACKS SET "+sb.ToString()+" WHERE ID=:id"))
                {
                    updatecommand.ExecuteNonQuery();
                }
                return true;
            }
        }

        public bool deleteTrack(Track track)
        {
            return deleteTrack(track.id);
        }

        public bool deleteTrack(string id)
        {
            using (SQLiteCommand insertcommand = Program.storage.GetCommand("DELETE FROM TRACKS WHERE ID=:id"))
            {
                insertcommand.Parameters.AddWithValue("id", id);
                int res = insertcommand.ExecuteNonQuery();
                if (res == 0) return false;
                else return true;
            }
        }
    }
}