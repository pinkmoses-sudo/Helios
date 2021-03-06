//  Copyright 2014 Craig Courtney
//  Copyright 2020 Helios Contributors
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.UDPInterface
{
    public abstract class NetworkFunction
    {
        protected NetworkFunction(BaseUDPInterface sourceInterface)
        {
            SourceInterface = sourceInterface;
        }

        public BaseUDPInterface SourceInterface { get; }

        public HeliosTriggerCollection Triggers { get; } = new HeliosTriggerCollection();

        public HeliosActionCollection Actions { get; } = new HeliosActionCollection();

        public HeliosValueCollection Values { get; } = new HeliosValueCollection();

        public abstract void Reset();

        public abstract ExportDataElement[] GetDataElements();

        public abstract void ProcessNetworkData(string id, string value);
    }
}
