// Tests/Vasis.MDFe.Infrastructure.Tests/External/ZeusMDFeWrapperTests.cs
using FluentAssertions;
using System.Threading.Tasks;
using Vasis.MDFe.Application.DTOs.Generation;
using Vasis.MDFe.Application.DTOs.Lifecycle;
using Vasis.MDFe.Application.DTOs.Query;
using Vasis.MDFe.Application.DTOs.Transmission;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Infrastructure.External;
using Xunit;

namespace Vasis.MDFe.Infrastructure.Tests.External
{
    public class ZeusMDFeWrapperTests
    {
        private readonly ZeusMDFeWrapper _wrapper;

        public ZeusMDFeWrapperTests()
        {
            _wrapper = new ZeusMDFeWrapper();
        }

        [Fact]
        public async Task CreateMDFe_WithValidRequest_ShouldReturnSuccess()
        {
            // Arrange
            var request = new CreateMDFeRequest
            {
                EmitenteCNPJ = "12345678000195",
                Serie = 1,
                Numero = 1,
                TipoEmitente = 1,
                UfInicioViagem = "SP",
                UfFimViagem = "RJ",
                Municipios = new List<MunicipioCarregamento>
                {
                    new MunicipioCarregamento { CodigoMunicipio = 3550308, NomeMunicipio = "São Paulo" }
                }
            };

            // Act
            var result = await _wrapper.CreateMDFeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.XmlMDFe.Should().NotBeEmpty();
            result.Data.ChaveAcesso.Should().HaveLength(44);
        }

        [Fact]
        public async Task SignMDFe_WithValidXml_ShouldReturnSignedXml()
        {
            // Arrange
            var request = new SignMDFeRequest
            {
                XmlMDFe = GetValidMDFeXml(),
                CertificadoPath = "certificado.pfx",
                CertificadoSenha = "senha123"
            };

            // Act
            var result = await _wrapper.SignMDFeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.XmlAssinado.Should().NotBeEmpty();
            result.Data.XmlAssinado.Should().Contain("<Signature");
        }

        [Fact]
        public async Task ValidateXml_WithValidXml_ShouldReturnValid()
        {
            // Arrange
            var request = new ValidateXmlRequest
            {
                XmlMDFe = GetValidSignedMDFeXml()
            };

            // Act
            var result = await _wrapper.ValidateXmlAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.IsValid.Should().BeTrue();
            result.Data.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task SendMDFe_WithValidXml_ShouldReturnProtocol()
        {
            // Arrange
            var request = new SendMDFeRequest
            {
                XmlAssinado = GetValidSignedMDFeXml(),
                Ambiente = 2 // Homologação
            };

            // Act
            var result = await _wrapper.SendMDFeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Protocolo.Should().NotBeEmpty();
            result.Data.Status.Should().Be("100");
            result.Data.Motivo.Should().Be("Autorizado o uso do MDFe");
        }

        [Fact]
        public async Task ConsultMDFe_WithValidKey_ShouldReturnMDFeData()
        {
            // Arrange
            var request = new ConsultMDFeRequest
            {
                ChaveAcesso = "35230812345678000195570010000000011123456789",
                Ambiente = 2
            };

            // Act
            var result = await _wrapper.ConsultMDFeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.ChaveAcesso.Should().Be(request.ChaveAcesso);
            result.Data.Status.Should().NotBeEmpty();
        }

        [Fact]
        public async Task CancelMDFe_WithValidRequest_ShouldReturnSuccess()
        {
            // Arrange
            var request = new CancelMDFeRequest
            {
                ChaveAcesso = "35230812345678000195570010000000011123456789",
                Protocolo = "135230000123456",
                Justificativa = "Cancelamento por erro na emissão"
            };

            // Act
            var result = await _wrapper.CancelMDFeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.ProtocoloCancelamento.Should().NotBeEmpty();
            result.Data.Status.Should().Be("135");
        }

        private string GetValidMDFeXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <MDFe xmlns=""http://www.portalfiscal.inf.br/mdfe"">
                        <infMDFe Id=""MDFe35230812345678000195570010000000011123456789"">
                            <ide>
                                <cUF>35</cUF>
                                <tpAmb>2</tpAmb>
                                <tpEmit>1</tpEmit>
                                <mod>58</mod>
                                <serie>1</serie>
                                <nMDF>1</nMDF>
                                <cMDF>12345678</cMDF>
                                <cDV>9</cDV>
                                <modal>01</modal>
                                <dhEmi>2023-08-15T10:30:00-03:00</dhEmi>
                                <tpEmis>1</tpEmis>
                                <procEmi>0</procEmi>
                                <verProc>1.0.0</verProc>
                                <UFIni>SP</UFIni>
                                <UFFim>RJ</UFFim>
                            </ide>
                        </infMDFe>
                    </MDFe>";
        }

        private string GetValidSignedMDFeXml()
        {
            return GetValidMDFeXml().Replace("</MDFe>",
                @"<Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
                    <SignedInfo>
                        <Reference URI=""#MDFe35230812345678000195570010000000011123456789"">
                            <DigestValue>ABC123...</DigestValue>
                        </Reference>
                    </SignedInfo>
                    <SignatureValue>XYZ789...</SignatureValue>
                </Signature>
                </MDFe>");
        }
    }
}