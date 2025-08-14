using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading;
using Microsoft.IdentityModel.Tokens;

#pragma warning disable 1591

#nullable disable
namespace IdentityServer4.Models;

/// <summary>
/// Represents a JSON Web Key as defined in https://datatracker.ietf.org/doc/html/rfc7517.
/// </summary>
public class JsonWebKey : SecurityKey
{
  internal const string ClassName = "Microsoft.IdentityModel.Tokens.JsonWebKey";
  private Dictionary<string, object> _additionalData;
  private List<string> _keyOps;
  private List<string> _oth;
  private List<string> _x5c;
  private string _kid;

  /// <summary>
  /// Initializes an new instance of <see cref="T:Microsoft.IdentityModel.Tokens.JsonWebKey" />.
  /// </summary>
  public JsonWebKey()
  {
  }

  /// <summary>
  /// When deserializing from JSON any properties that are not defined will be placed here.
  /// </summary>
  [JsonExtensionData]
  public IDictionary<string, object> AdditionalData
  {
    get
    {
      return (IDictionary<string, object>) this._additionalData ?? (IDictionary<string, object>) Interlocked.CompareExchange<Dictionary<string, object>>(ref this._additionalData, new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.Ordinal), (Dictionary<string, object>) null) ?? (IDictionary<string, object>) this._additionalData;
    }
  }

  /// <summary>Gets or sets the 'alg' (KeyType).</summary>
  [JsonPropertyName("alg")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Alg { get; set; }

  /// <summary>Gets or sets the 'crv' (ECC - Curve).</summary>
  [JsonPropertyName("crv")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Crv { get; set; }

  /// <summary>
  /// Gets or sets the 'd' (ECC - Private Key OR RSA - Private Exponent).
  /// </summary>
  /// <remarks>Value is formated as: Base64urlUInt</remarks>
  [JsonPropertyName("d")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string D { get; set; }

  /// <summary>
  /// Gets or sets the 'dp' (RSA - First Factor CRT Exponent).
  /// </summary>
  /// <remarks>Value is formated as: Base64urlUInt</remarks>
  [JsonPropertyName("dp")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string DP { get; set; }

  /// <summary>
  /// Gets or sets the 'dq' (RSA - Second Factor CRT Exponent).
  /// </summary>
  /// <remarks>Value is formated as: Base64urlUInt</remarks>
  [JsonPropertyName("dq")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string DQ { get; set; }

  /// <summary>Gets or sets the 'e' (RSA - Exponent).</summary>
  [JsonPropertyName("e")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string E { get; set; }

  /// <summary>Gets or sets the 'k' (Symmetric - Key Value).</summary>
  /// 
  ///             Base64urlEncoding
  [JsonPropertyName("k")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string K { get; set; }

  /// <summary>
  /// Gets the key id of this <see cref="T:Microsoft.IdentityModel.Tokens.JsonWebKey" />.
  /// </summary>
  [JsonIgnore]
  public override string KeyId
  {
    get => this._kid;
    set => this._kid = value;
  }

  /// <summary>Gets the 'key_ops' (Key Operations).</summary>
  [JsonPropertyName("key_ops")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public IList<string> KeyOps
  {
    get
    {
      return (IList<string>) this._keyOps ?? (IList<string>) Interlocked.CompareExchange<List<string>>(ref this._keyOps, new List<string>(), (List<string>) null) ?? (IList<string>) this._keyOps;
    }
  }

  /// <summary>Gets or sets the 'kid' (Key ID)..</summary>
  [JsonPropertyName("kid")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Kid
  {
    get => this._kid;
    set => this._kid = value;
  }

  /// <summary>Gets or sets the 'kty' (Key Type).</summary>
  [JsonPropertyName("kty")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Kty { get; set; }

  /// <summary>Gets or sets the 'n' (RSA - Modulus).</summary>
  /// <remarks>Value is formatted as: Base64urlEncoding</remarks>
  [JsonPropertyName("n")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string N { get; set; }

  /// <summary>Gets or sets the 'oth' (RSA - Other Primes Info).</summary>
  [JsonPropertyName("oth")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public IList<string> Oth
  {
    get
    {
      return (IList<string>) this._oth ?? (IList<string>) Interlocked.CompareExchange<List<string>>(ref this._oth, new List<string>(), (List<string>) null) ?? (IList<string>) this._oth;
    }
  }

  /// <summary>Gets or sets the 'p' (RSA - First Prime Factor)..</summary>
  /// <remarks>Value is formatted as: Base64urlUInt</remarks>
  [JsonPropertyName("p")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string P { get; set; }

  /// <summary>Gets or sets the 'q' (RSA - Second  Prime Factor)..</summary>
  /// <remarks>Value is formatted as: Base64urlUInt</remarks>
  [JsonPropertyName("q")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Q { get; set; }

  /// <summary>Gets or sets the 'qi' (RSA - First CRT Coefficient)..</summary>
  /// <remarks>Value is formatted as: Base64urlUInt</remarks>
  [JsonPropertyName("qi")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string QI { get; set; }

  /// <summary>Gets or sets the 'use' (Public Key Use)..</summary>
  [JsonPropertyName("use")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Use { get; set; }

  /// <summary>Gets or sets the 'x' (ECC - X Coordinate)..</summary>
  /// <remarks>Value is formatted as: Base64urlEncoding</remarks>
  [JsonPropertyName("x")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string X { get; set; }

  /// <summary>Gets the 'x5c' collection (X.509 Certificate Chain)..</summary>
  [JsonPropertyName("x5c")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public IList<string> X5c
  {
    get
    {
      return (IList<string>) this._x5c ?? (IList<string>) Interlocked.CompareExchange<List<string>>(ref this._x5c, new List<string>(), (List<string>) null) ?? (IList<string>) this._x5c;
    }
  }

  /// <summary>
  /// Gets or sets the 'x5t' (X.509 Certificate SHA-1 thumbprint)..
  /// </summary>
  [JsonPropertyName("x5t")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string X5t { get; set; }

  /// <summary>
  /// Gets or sets the 'x5t#S256' (X.509 Certificate SHA-256 thumbprint)..
  /// </summary>
  [JsonPropertyName("x5t#S256")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string X5tS256 { get; set; }

  /// <summary>Gets or sets the 'x5u' (X.509 URL)..</summary>
  [JsonPropertyName("x5u")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string X5u { get; set; }

  /// <summary>Gets or sets the 'y' (ECC - Y Coordinate)..</summary>
  /// <remarks>Value is formatted as: Base64urlEncoding</remarks>
  [JsonPropertyName("y")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string Y { get; set; }

  /// <summary>
  /// Gets the key size of <see cref="T:Microsoft.IdentityModel.Tokens.JsonWebKey" />.
  /// </summary>
  [JsonIgnore]
  public override int KeySize
  {
    get
    {
      if (this.Kty == "RSA" && !string.IsNullOrEmpty(this.N))
        return Base64UrlEncoder.DecodeBytes(this.N).Length * 8;
      if (this.Kty == "EC" && !string.IsNullOrEmpty(this.X))
        return Base64UrlEncoder.DecodeBytes(this.X).Length * 8;
      return this.Kty == "oct" && !string.IsNullOrEmpty(this.K) ? Base64UrlEncoder.DecodeBytes(this.K).Length * 8 : 0;
    }
  }

  /// <summary>Gets a bool indicating if a private key exists.</summary>
  /// <return>true if it has a private key; otherwise, false.</return>
  [JsonIgnore]
  public bool HasPrivateKey
  {
    get
    {
      return this.Kty == "RSA" ? this.D != null && this.DP != null && this.DQ != null && this.P != null && this.Q != null && this.QI != null : this.Kty == "EC" && this.D != null;
    }
  }
  
  
  /// <summary>
  /// Returns the formatted string: GetType(), Use: 'value', Kid: 'value', Kty: 'value', InternalId: 'value'.
  /// </summary>
  /// <returns>string</returns>
  public override string ToString()
  {
    return $"{this.GetType()}, Use: '{this.Use}',  Kid: '{this.Kid}', Kty: '{this.Kty}'.";
  }
}
